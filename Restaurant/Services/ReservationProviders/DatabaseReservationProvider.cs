using Microsoft.EntityFrameworkCore;
using Restaurant.DbContexts;
using Restaurant.DTOs;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
        private readonly RestaurantDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(RestaurantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (RestaurantDbContext context = _dbContextFactory.CreateDbContext())
            {
                await Task.Delay(3000);

                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Reservation ToReservation(ReservationDTO dto)
        {
            return new Reservation(new TableID(dto.FloorNumber, dto.TableNumber), dto.Name, dto.ResTime);
        }
    }
}
