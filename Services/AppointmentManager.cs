using AutoMapper;
using Entities.DataTransferObjects.Appointment;
using Entities.DataTransferObjects.DoctorSchedule;
using Entities.DataTransferObjects.User;
using Entities.Exceptions.Appointment;
using Entities.Exceptions.Doctor;
using Entities.Exceptions.DoctorSchedule;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using Services.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.NotFoundException;
using static System.Net.Mime.MediaTypeNames;

namespace Services
{
    public class AppointmentManager : IAppointmentService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;


        private IMapper mapper;
   
       
        public AppointmentManager(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
   
        }


  
        public async Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(string doctorId, bool trackChanges, DateTime? month = null)
        {
            var appointments = await _repository.Appointment.GetDoctorAppointmentsAsync(doctorId, trackChanges);

            if (month.HasValue)
            {
                appointments = appointments.Where(a => a.StartTime.Year == month.Value.Year && a.StartTime.Month == month.Value.Month).ToList();
            }

            return appointments;
        }

        public async Task<IEnumerable<Appointment>> GetDoctorAppointmentsAsync(string doctorId, bool trackChanges)
        {
            var appointments = await _repository.Appointment.GetDoctorAppointmentsAsync(doctorId, trackChanges);

           

            return appointments;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsInAMonthAsync(DateTime? month = null)
        {
            var appointments = await _repository.Appointment.GetAllDoctorAppointmentsAsync();

            if (month.HasValue)
            {
                appointments = appointments.Where(a => a.StartTime.Year == month.Value.Year && a.StartTime.Month == month.Value.Month).ToList();
            }

            return appointments;
        }

        public async Task<IEnumerable<TimeSlotDto>> GetAvailableSlotsAsync(string doctorId, DateTime month)
        {
            var schedules = await _repository.DoctorSchedule.GetDoctorSchedulesAsync(doctorId, false);
            var doctor = await _userManager.FindByIdAsync(doctorId);
            var doctorTableCategoryInfo = await _repository.Doctor.GetOneDoctorByUserIdAsync(doctorId, false);
            var doctorCategory = await _repository.DoctorCategory.GetOneDoctorCategoryAsync(doctorTableCategoryInfo.DoctorCategoryId, false);
            var appointments = await this.GetDoctorAppointmentsAsync(doctorId, false, month);

            var availableSlots = new List<TimeSlotDto>();

            foreach (var schedule in schedules)
            {
                if (schedule.AvailableFrom.Month == month.Month && schedule.AvailableFrom.Year == month.Year)
                {
                    var currentTime = schedule.AvailableFrom;
                    while (currentTime < schedule.AvailableTo)
                    {
                        var nextSlotTime = currentTime.AddHours(1);
                        var overlappingAppointment = appointments.FirstOrDefault(a => a.StartTime < nextSlotTime && a.EndTime > currentTime);
                        UserDto? userDto = null;

                        if (overlappingAppointment != null)
                        {
                            var user = await _userManager.FindByIdAsync(overlappingAppointment.UserId);
                            userDto = _mapper.Map<UserDto>(user);
                        }

                        availableSlots.Add(new TimeSlotDto
                        {
                            ScheduleId = schedule.Id,
                            StartTime = currentTime,
                            EndTime = nextSlotTime,
                            IsBooked = overlappingAppointment != null,
                            DoctorCategoryName = doctorCategory.DoctorCategoryName,
                            DoctorNameSurname = $"{doctor.UserName} {doctor.Surname}",
                            AppointmentId = overlappingAppointment?.Id,
                            User = userDto
                        });

                        currentTime = nextSlotTime.AddMinutes(10); // 1 saat randevu ve 10 dakika mola
                    }
                }
            }

            return availableSlots;
        }

        public async Task<IEnumerable<TimeSlotDto>> GetFutureAvailableSlotsAsync(string doctorId, DateTime month)
        {
            var schedules = await _repository.DoctorSchedule.GetDoctorSchedulesAsync(doctorId, false);
            var doctor = await _userManager.FindByIdAsync(doctorId);
            var doctorTableCategoryInfo = await _repository.Doctor.GetOneDoctorByUserIdAsync(doctorId, false);
            var doctorCategory = await _repository.DoctorCategory.GetOneDoctorCategoryAsync(doctorTableCategoryInfo.DoctorCategoryId, false);
            var appointments = await this.GetDoctorAppointmentsAsync(doctorId, false, month);

            var availableSlots = new List<TimeSlotDto>();

            foreach (var schedule in schedules)
            {
                if (schedule.AvailableFrom.Month == month.Month && schedule.AvailableFrom.Year == month.Year)
                {
                    var currentTime = schedule.AvailableFrom;
                    while (currentTime < schedule.AvailableTo)
                    {
                        if (currentTime >= DateTime.Now) // Only consider future slots
                        {
                            var nextSlotTime = currentTime.AddHours(1);
                            var overlappingAppointment = appointments.FirstOrDefault(a => a.StartTime < nextSlotTime && a.EndTime > currentTime);
                            UserDto? userDto = null;

                            if (overlappingAppointment != null)
                            {
                                var user = await _userManager.FindByIdAsync(overlappingAppointment.UserId);
                                userDto = _mapper.Map<UserDto>(user);
                            }

                            availableSlots.Add(new TimeSlotDto
                            {
                                ScheduleId = schedule.Id,
                                StartTime = currentTime,
                                EndTime = nextSlotTime,
                                IsBooked = overlappingAppointment != null,
                                DoctorCategoryName = doctorCategory.DoctorCategoryName,
                                DoctorNameSurname = $"{doctor.UserName} {doctor.Surname}",
                                AppointmentId = overlappingAppointment?.Id,
                                User = userDto
                            });
                        }

                        currentTime = currentTime.AddHours(1).AddMinutes(10); // 1 hour appointment and 10 minutes break
                    }
                }
            }

            return availableSlots;
        }


        public async Task<IEnumerable<TimeSlotDtoGetAll>> GetAllDoctorsAvailableSlotsAsync(DateTime month, int? categoryId = null)
        {
            var schedules = await _repository.DoctorSchedule.GetAllDoctorSchedules();
            var appointments = await this.GetAppointmentsInAMonthAsync(month);

            var availableSlots = new List<TimeSlotDtoGetAll>();

            foreach (var schedule in schedules)
            {
                if (schedule.AvailableFrom.Month == month.Month && schedule.AvailableFrom.Year == month.Year)
                {
                    var doctor = await _repository.Doctor.GetOneDoctorByUserIdAsync(schedule.DoctorId, false);
                    if (categoryId.HasValue && doctor.DoctorCategoryId != categoryId.Value)
                    {
                        continue; // Skip this doctor if the category does not match
                    }

                    var currentTime = schedule.AvailableFrom;
                    while (currentTime < schedule.AvailableTo)
                    {
                        var nextSlotTime = currentTime.AddHours(1);
                        var isBooked = appointments.Any(a => a.StartTime < nextSlotTime && a.EndTime > currentTime);
                        var doctorCategory = await _repository.DoctorCategory.GetOneDoctorCategoryAsync(doctor.DoctorCategoryId, false);
                        var doctorNameSurnameInfo = await _userManager.FindByIdAsync(doctor.UserId);

                        availableSlots.Add(new TimeSlotDtoGetAll
                        {
                            StartTime = currentTime,
                            EndTime = nextSlotTime,
                            IsBooked = isBooked,
                            DoctorCategoryName = doctorCategory.DoctorCategoryName,
                            DoctorNameSurname = $"{doctorNameSurnameInfo.UserName} {doctorNameSurnameInfo.Surname}",
                            DoctorId = doctor.UserId,
                            DoctorCategoryId = doctorCategory.DoctorCategoryId,
                        });

                        currentTime = nextSlotTime.AddMinutes(10); // 1 hour appointment and 10 minutes break
                    }
                }
            }

            return availableSlots;
        }
        public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentDto appointmentDto)
        {
            // Randevu süresi 1 saat olarak belirlendi
            var appointmentDuration = TimeSpan.FromMinutes(15);
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            // Randevu bitiş süresi otomatik olarak hesaplanır
            appointment.EndTime = appointment.StartTime.Add(appointmentDuration);

            // Randevu başlangıç zamanının geçip geçmediğini kontrol et
            if (appointment.StartTime < DateTime.Now)
            {
                throw new InvalidAppointmentTimeException("The appointment time has already passed.");
            }

            // Doktorun çalışma saatleri içinde olup olmadığını kontrol et
            var isDoctorAvailable = await CheckDoctorAvailability(appointment.DoctorId, appointment.StartTime, appointment.EndTime);
            if (!isDoctorAvailable)
            {
                throw new AppointmentConflictException(appointment.DoctorId, appointment.StartTime);
            }

            // Mevcut randevularla çakışma olup olmadığını kontrol et
            var existingAppointments = await _repository.Appointment.FindByCondition(a => a.DoctorId == appointment.DoctorId &&
                                                                                           ((a.StartTime >= appointment.StartTime && a.StartTime < appointment.EndTime) ||
                                                                                            (a.EndTime > appointment.StartTime && a.EndTime <= appointment.EndTime)), false)
                                                                                           .ToListAsync();

            if (existingAppointments.Any())
            {
                throw new AppointmentConflictException(appointment.DoctorId, appointment.StartTime);
            }

            // Randevu oluşturulduğunda Status alanını "Booked" olarak günceller
            appointment.Status = "Booked";

            await _repository.Appointment.CreateAppointmentAsync(appointment);
            var createdAppointment = _mapper.Map<AppointmentDto>(appointment);
            await _repository.SaveAsync();
            return createdAppointment;
        }

        private async Task<bool> CheckDoctorAvailability(string doctorId, DateTime startTime, DateTime endTime)
        {
          
            var schedules = await _repository.DoctorSchedule.FindByCondition(ds => ds.DoctorId == doctorId, false).ToListAsync();
            var isWithinSchedule = schedules.Any(schedule =>
                startTime >= schedule.AvailableFrom && endTime <= schedule.AvailableTo);

         
            var appointments = await _repository.Appointment.FindByCondition(a => a.DoctorId == doctorId &&
                                                                                  ((a.Status == null || a.Status == "Available") &&
                                                                                  ((a.StartTime >= startTime && a.StartTime < endTime) ||
                                                                                  (a.EndTime > startTime && a.EndTime <= endTime))), false)
                                                                                  .ToListAsync();

            return isWithinSchedule && !appointments.Any();
        }




        public async Task DeleteAppointmentAsync(int appointmentId)
        {
            var appointment = await _repository.Appointment.GetAppointmentByIdAsync(appointmentId, true);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException(appointmentId);
            }

            _repository.Appointment.Delete(appointment);
            await _repository.SaveAsync();
        }
        public async Task<IEnumerable<AppointmentDto>> GetUserAppointmentsAsync(string userId, bool trackChanges)
        {
            var appointments = await _repository.Appointment.FindByCondition(a => a.UserId == userId, trackChanges)
                                                             .ToListAsync();

            var appointmentDtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return appointmentDtos;
        }

        public async Task<IEnumerable<Appointment>> GetUserAppointmentsDetailsByIdAsync(string userId, bool trackChanges)
        {
            var appointments = await _repository.Appointment.FindByCondition(a => a.UserId == userId, trackChanges)
                                                             .ToListAsync();

           
            return appointments;
        }


        public async Task<IEnumerable<TimeSlotDtoGetAll>> SearchDoctorSchedulesAsync(string query)
        {
            var schedules = await _repository.DoctorSchedule.GetAllDoctorSchedules();
            var filteredSchedules = new List<DoctorSchedule>();

            foreach (var schedule in schedules)
            {
                var doctor = await _repository.Doctor.GetOneDoctorByUserIdAsync(schedule.DoctorId, false);
                var doctorNameSurnameInfo = await _userManager.FindByIdAsync(doctor.UserId);
                var doctorCategory = await _repository.DoctorCategory.GetOneDoctorCategoryAsync(doctor.DoctorCategoryId, false);

                if ((doctorNameSurnameInfo.UserName + " " + doctorNameSurnameInfo.Surname).Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    doctorCategory.DoctorCategoryName.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    filteredSchedules.Add(schedule);
                }
            }

            var availableSlots = new List<TimeSlotDtoGetAll>();

            foreach (var schedule in filteredSchedules)
            {
                var doctor = await _repository.Doctor.GetOneDoctorByUserIdAsync(schedule.DoctorId, false);
                var doctorCategory = await _repository.DoctorCategory.GetOneDoctorCategoryAsync(doctor.DoctorCategoryId, false);
                var doctorNameSurnameInfo = await _userManager.FindByIdAsync(doctor.UserId);
                var appointments = await this.GetDoctorAppointmentsAsync(schedule.DoctorId, false);
                var currentTime = schedule.AvailableFrom;
                while (currentTime < schedule.AvailableTo)
                {
                    var nextSlotTime = currentTime.AddHours(1);
                    var isBooked = appointments.Any(a => a.StartTime < nextSlotTime && a.EndTime > currentTime); // Booking status can be set if necessary
                    availableSlots.Add(new TimeSlotDtoGetAll
                    {
                        StartTime = currentTime,
                        EndTime = nextSlotTime,
                        IsBooked = isBooked,
                        DoctorCategoryName = doctorCategory.DoctorCategoryName,
                        DoctorNameSurname = $"{doctorNameSurnameInfo.UserName} {doctorNameSurnameInfo.Surname}",
                        DoctorId = doctor.UserId,
                        DoctorCategoryId = doctorCategory.DoctorCategoryId,
                    });

                    currentTime = nextSlotTime.AddMinutes(10); // 1 hour appointment and 10 minutes break
                }
            }

            return availableSlots;
        }




    }
}
