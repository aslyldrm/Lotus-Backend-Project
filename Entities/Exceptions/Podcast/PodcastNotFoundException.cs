﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.Podcast
{
    public class PodcastNotFoundException : NotFoundException
    {
        public PodcastNotFoundException(int id) : base($"The Podcast with id : {id} could not found.")
        {
        }
    }
}
