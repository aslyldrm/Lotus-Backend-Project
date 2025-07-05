using AutoMapper;
using Entities.DataTransferObjects.DoctorSchedule;
using Entities.Exceptions.DoctorSchedule;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DoctorScheduleManager : IDoctorScheduleService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DoctorScheduleManager(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorScheduleDto>> GetDoctorSchedulesAsync(string doctorId, bool trackChanges)
        {
            var schedules = await _repository.DoctorSchedule.GetDoctorSchedulesAsync(doctorId, trackChanges);
            var scheduleDtos = schedules.Select(schedule => new DoctorScheduleDto
            {
                DoctorId = schedule.DoctorId,
                AvailableFrom = schedule.AvailableFrom,
                AvailableTo = schedule.AvailableTo,
                AppointmentDurationInMinutes = (int)(schedule.AvailableTo - schedule.AvailableFrom).TotalMinutes // Hesaplama burada yapılıyor
            });

            return scheduleDtos;
        }

        public async Task<DoctorScheduleDto> GetDoctorScheduleByIdAsync(int id, bool trackChanges)
        {
            var schedule = await _repository.DoctorSchedule.GetDoctorScheduleByIdAsync(id, trackChanges);
            if (schedule == null)
            {
                throw new ScheduleNotFoundException(id.ToString());
            }

            var scheduleDto = new DoctorScheduleDto
            {
                DoctorId = schedule.DoctorId,
                AvailableFrom = schedule.AvailableFrom,
                AvailableTo = schedule.AvailableTo,
                AppointmentDurationInMinutes = (int)(schedule.AvailableTo - schedule.AvailableFrom).TotalMinutes // Hesaplama burada yapılıyor
            };

            return scheduleDto;
        }


        //public async Task UpdateDoctorScheduleAsync(int id, UpdateDoctorScheduling scheduleDto)
        //{
        //    var schedule = await _repository.DoctorSchedule.GetDoctorScheduleByIdAsync(id, true);
        //    if (schedule == null)
        //    {
        //        throw new ScheduleNotFoundException(id.ToString());
        //    }

        //    // Mevcut randevuları al
        //    var appointments = await _repository.Appointment.FindByCondition(a => a.DoctorId == schedule.DoctorId &&
        //                                                                        ((a.StartTime >= scheduleDto.AvailableFrom && a.StartTime < scheduleDto.AvailableTo) ||
        //                                                                        (a.EndTime > scheduleDto.AvailableFrom && a.EndTime <= scheduleDto.AvailableTo)), false)
        //                                                    .ToListAsync();

        //    // Çakışma kontrolü
        //    if (appointments.Any())
        //    {
        //        throw new ScheduleConflictException("The new schedule conflicts with existing appointments.");
        //    }

        //    // Güncellemeyi uygula
        //    _mapper.Map(scheduleDto, schedule);
        //    await _repository.DoctorSchedule.UpdateDoctorScheduleAsync(schedule);
        //    await _repository.SaveAsync();
        //}
        public async Task<DoctorSchedule> UpdateDoctorScheduleAsync(int id, UpdateDoctorScheduling scheduleDto)
        {
            var schedule = await _repository.DoctorSchedule.GetDoctorScheduleByIdAsync(id, true);
            if (schedule == null)
            {
                throw new ScheduleNotFoundException(id.ToString());
            }

            // Mevcut randevuları al
            var appointments = await _repository.Appointment.FindByCondition(a => a.DoctorId == schedule.DoctorId &&
                                                                                    ((a.StartTime >= scheduleDto.AvailableFrom && a.StartTime < scheduleDto.AvailableTo) ||
                                                                                    (a.EndTime > scheduleDto.AvailableFrom && a.EndTime <= scheduleDto.AvailableTo)), false)
                                                                .ToListAsync();

            // Çakışma kontrolü
            if (appointments.Any())
            {
                throw new ScheduleConflictException("The new schedule conflicts with existing appointments.");
            }

            // Güncellemeyi uygula
            _mapper.Map(scheduleDto, schedule);
            await _repository.DoctorSchedule.UpdateDoctorScheduleAsync(schedule);
            await _repository.SaveAsync();

            return schedule;
        }


        public async Task<DoctorSchedule> DeleteDoctorScheduleAsync(int id, bool trackChanges)
        {
            var schedule = await _repository.DoctorSchedule.GetDoctorScheduleByIdAsync(id, trackChanges);
            if (schedule == null)
            {
                throw new ScheduleNotFoundException(id.ToString());
            }
            await _repository.DoctorSchedule.DeleteDoctorScheduleAsync(schedule);
            await _repository.SaveAsync();

            return schedule;
        }

        public async Task<IEnumerable<DoctorSchedule>> CreateDoctorSchedulesAsync(DoctorScheduleDto scheduleDto)
        {
            // Calculate the duration for the entire available slot
            var totalAvailableDuration = scheduleDto.AvailableTo - scheduleDto.AvailableFrom;

            // Use the provided appointment duration, or default to the total available duration if it's zero
            var appointmentDuration = scheduleDto.AppointmentDurationInMinutes > 0
                ? TimeSpan.FromMinutes(scheduleDto.AppointmentDurationInMinutes)
                : totalAvailableDuration;

            var breakDuration = TimeSpan.FromMinutes(scheduleDto.BreakMinutes);

            if (totalAvailableDuration < TimeSpan.FromMinutes(15))
            {
                throw new InvalidScheduleTimeException("Randevu süresi geçerli değildir. 15 dakikadan fazla yapınız.");
            }
            if (scheduleDto.AvailableFrom < DateTime.Now)
            {
                throw new InvalidScheduleTimeException("Randevu zamanı zaten geçti.");
            }

            // Mevcut programların çakışma kontrolü
            var existingSchedules = await _repository.DoctorSchedule.FindByCondition(
                s => s.DoctorId == scheduleDto.DoctorId &&
                     ((s.AvailableFrom >= scheduleDto.AvailableFrom && s.AvailableFrom < scheduleDto.AvailableTo) ||
                     (s.AvailableTo > scheduleDto.AvailableFrom && s.AvailableTo <= scheduleDto.AvailableTo)), false)
                .ToListAsync();

            if (existingSchedules.Any())
            {
                throw new InvalidScheduleTimeException("Yeni randevu mevcut randevularla çakışıyor. Lütfen değiştiriniz.");
            }

            var schedules = GenerateDoctorSchedules(scheduleDto, appointmentDuration, breakDuration);

            foreach (var schedule in schedules)
            {
                await _repository.DoctorSchedule.CreateDoctorScheduleAsync(schedule);
            }
            await _repository.SaveAsync();

            return schedules;
        }

        private IEnumerable<DoctorSchedule> GenerateDoctorSchedules(DoctorScheduleDto scheduleDto, TimeSpan appointmentDuration, TimeSpan breakDuration)
        {
            var schedules = new List<DoctorSchedule>();
            var currentTime = scheduleDto.AvailableFrom;

            if (appointmentDuration == scheduleDto.AvailableTo - scheduleDto.AvailableFrom || breakDuration == TimeSpan.Zero)
            {
                // Create a single appointment if the appointment duration covers the entire available time or break duration is zero
                var endTime = scheduleDto.AvailableTo;
                schedules.Add(new DoctorSchedule
                {
                    DoctorId = scheduleDto.DoctorId,
                    AvailableFrom = currentTime,
                    AvailableTo = endTime
                });
            }
            else
            {
                // Create multiple appointments with breaks
                while (currentTime.Add(appointmentDuration) <= scheduleDto.AvailableTo)
                {
                    var endTime = currentTime.Add(appointmentDuration);
                    schedules.Add(new DoctorSchedule
                    {
                        DoctorId = scheduleDto.DoctorId,
                        AvailableFrom = currentTime,
                        AvailableTo = endTime
                    });

                    currentTime = endTime.Add(breakDuration); // Add break duration to determine the next start time
                }
            }

            return schedules;
        }



    }
}
