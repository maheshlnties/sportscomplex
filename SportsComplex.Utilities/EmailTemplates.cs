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

        #region Employees

        public const string ResourceBookingBody =
            "Hi, You have booked: {0} resource. Amount {1} will be deducted from current month payroll.";

        public const string GymJoiningBody =
            "Hi, You have joined Gym. Amount {0} will be deducted from current month payroll.";

        public const string GymLeavingBody = "Hi, You have left Gym. Thank you for using Gym!";

        public const string TournmentEnrollBody =
            "Hi, You have enrolled for tournment: {0}. Amount {1} will be deducted from current month payroll.";

        #endregion

        #region Payroll
        
        public const string PayrollResourceBookingBody =
            "Hi, PS Number - {0} have booked: {1} resource. Deduct {2} from upcoming payroll salary";

        public const string PayrollGymJoiningBody =
            "Hi, PS Number - {0} have joined Gym. Initiate deduction {1} from upcoming payroll salary";

        public const string PayrollGymLeavingBody = "Hi,  PS Number - {0} have left Gym. Stop deduction {1} from current month payroll salary";

        public const string PayrollTournmentEnrollBody =
            "Hi, PS Number - {0} have enrolled for tournment: {1}. Deduct {2} from current month payroll salary";
        
        #endregion

        #endregion
    }
}
