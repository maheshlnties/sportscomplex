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

        bool UploadImages(List<Image> images);

        List<Image> GetGalleryImages();

        bool DeleteImages(List<string> imageId);

        bool JoinGym(Gym gym);

        bool LeaveGym(string id);

        Gym GetGymDetails(string psNumber);

        bool IsUserExists(string psNumber);

        string GetUserName(string psNumber);

        string GetEmail(string psNumber);
    }
}
