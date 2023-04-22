using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Notification
    {
        #region Attributes

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notification> Notifications { get; set; }

        #endregion

        #region Constructor

        public Notification()
        {
            Notifications = new List<Notification>();
        }

        #endregion

        #region Behaviors

        public bool ValidateInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notification
                {
                    Message = "This field is mandatory.",
                    PropertyName = propertyName,
                });

                return false;
            }

            return true;
        }

        public bool ValidateString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notifications.Add(new Notification
                {
                    Message = "This field is mandatory.",
                    PropertyName = propertyName,
                });

                return false;
            }

            return true;
        }

        #endregion
    }
}
