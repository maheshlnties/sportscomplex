using System;
using System.Collections.Generic;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IModuleService
    {
        bool BookBadmintonResource(Resource resource);

        bool BookBilliardResource(Resource resource);

        Resource GetBadmintonResource();

        Resource GetBilliardResource();

        List<BookingItem> GetBookedBadmintonList(DateTime date);

        List<BookingItem> GetBookedBilliardList(DateTime date);
    }
}
