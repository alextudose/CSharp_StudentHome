using System;
using StudentHome.Domain;

namespace StudentHome.Service
{
    public class StudentHomeValidator : IValidator<Domain.StudentHome>
    {
        private Domain.StudentHome studentHome;
        public string Validate(Domain.StudentHome studentHome)
        {
            string errors = string.Empty;
            if (studentHome.RoomSize < 0)
                errors = String.Concat(errors,
                    string.Format("{0}{1}", "Numarul persoanelor in camera nu poate fi negativ!",
                    Environment.NewLine));

            if (studentHome.NumberOfRooms < 0)
                errors = String.Concat(errors,
                    string.Format("{0}{1}", "Numarul camerelor de StudentHome nu poate fi negativ!",
                    Environment.NewLine));

            if (studentHome.Tax < 0)
                errors = String.Concat(errors,
                    string.Format("{0}{1}", "Regia de StudentHome nu poate fi negativa!",
                    Environment.NewLine));

            return errors;
        }
    }
}
