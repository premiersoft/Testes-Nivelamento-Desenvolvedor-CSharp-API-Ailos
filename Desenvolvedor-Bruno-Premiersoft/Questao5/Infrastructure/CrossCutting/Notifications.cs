using Questao5.Domain.Enumerators;

namespace Questao5.Infrastructure.CrossCutting
{
    public class Notifications
    {
        public PriorityEnum Priority { get; set; }
        public TypeNotificationNotyEnum TypeNotificationNoty { get; set; }
        public string Message { get; set; }
        public List<string> PropertsErrors { get; set; }

        public Notifications()
        {
            Priority = PriorityEnum.Average;
            TypeNotificationNoty = TypeNotificationNotyEnum.Error;
            PropertsErrors = new List<string>();
        }
    }
}
