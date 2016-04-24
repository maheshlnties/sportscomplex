namespace SportsComplex.Utilities
{
    public class EmailTemplates
    {
        #region Subjects

        public const string ResourceBookingSubject = "Resource Booking Acknowledgment";

        public const string GymJoiningSubject = "Gym Joining Acknowledgment";

        public const string GymLeavingSubject = "Gym Leaving Acknowledgment";

        public const string TournmentEnrollSubject = "Tournment Enrollment Acknowledgment";

        #endregion

        #region Body

        public const string ResourceBookingBody = "Hi, You have booked: {0} resource. Amount will be deducted from current month payroll.";

        public const string GymJoiningBody = "Hi, You have joined Gym. Amount will be deducted from current month payroll.";

        public const string GymLeavingBody = "Hi, You have left Gym. Thank you for using Gym!";

        public const string TournmentEnrollBody = "Hi, You have enrolled for tournment: {0}. Amount will be deducted from current month payroll.";

        #endregion
    }
}
