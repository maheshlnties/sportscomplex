using System.Collections.Generic;
using System.Linq;
using SportsComplex.Application.ViewModels;
using SportsComplex.Models.Charges;

namespace SportsComplex.Application.Helper
{
    public class ModelConverters
    {
        public static List<ChargeViewModel> FromGymChargesList(IList<GymCharge> gymCharges)
        {
            var list = new List<ChargeViewModel>();
            if (gymCharges != null)
            {
                list.AddRange(gymCharges.Select(FromGymCharges));
            }
            return list;
        }

        public static List<ChargeViewModel> FromTournmentChargesList(IList<TournmentCharge> tournmentCharges)
        {
            var list = new List<ChargeViewModel>();
            if (tournmentCharges != null)
            {
                list.AddRange(tournmentCharges.Select(FromTournmentCharges));
            }
            return list;
        }

        public static List<ChargeViewModel> FromResourceChargesList(IList<ResourceCharge> resourceCharges)
        {
            var list = new List<ChargeViewModel>();
            if (resourceCharges != null)
            {
                list.AddRange(resourceCharges.Select(FromResourceCharges));
            }
            return list;
        }

        private static ChargeViewModel FromGymCharges(GymCharge gymCharge)
        {
            return new ChargeViewModel
            {
                Name = gymCharge.Name,
                PsNumber = gymCharge.PsNumber,
                Charges = gymCharge.Charges,
                StartDate = gymCharge.JoinedOn,
                GymStatus = gymCharge.Joined ? "Joined" : "Left",
                EndDate = gymCharge.LeftOn,
                TransactionDate = gymCharge.TransactionDate.ToLongDateString()
            };
        }

        private static ChargeViewModel FromTournmentCharges(TournmentCharge tournmentCharge)
        {
            return new ChargeViewModel
            {
                Name = tournmentCharge.Name,
                PsNumber = tournmentCharge.PsNumber,
                Charges = tournmentCharge.Charges,
                TournmentName = tournmentCharge.TournmentName,
                TransactionDate= tournmentCharge.TransactionDate.ToLongDateString()
            };
        }

        private static ChargeViewModel FromResourceCharges(ResourceCharge resourceViewModel)
        {
            return new ChargeViewModel
            {
                Name = resourceViewModel.Name,
                PsNumber = resourceViewModel.PsNumber,
                Charges = resourceViewModel.Charges,
                ResourceName = resourceViewModel.ResourceName,
                Slot = resourceViewModel.Slot,
                TransactionDate = resourceViewModel.TransactionDate.ToShortDateString()
            };
        }
    }
}