﻿using HotelCollab.Areas.Manager.ViewModels;
using HotelCollab.Data;
using HotelCollab.Data.Models;
using HotelCollab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCollab.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventRepo;

        public EventService(IRepository<Event> eventRepo)
        {
            this.eventRepo = eventRepo;
        }

        public async Task AddEventAsync(CreateEventViewModel model, string hotelId)
        {
            var date = DateTime.ParseExact($"{model.Date}T{model.Time}", "dd.MM.yyyyTHH:mm", CultureInfo.InvariantCulture);

            var @event = new Event()
            {
                Title = model.Title,
                Date = date,
                Description = model.Description,
                HotelId = hotelId,
            };

            await eventRepo.AddAsync(@event);
            await eventRepo.SaveChangesAsync();
        }
    }
}
