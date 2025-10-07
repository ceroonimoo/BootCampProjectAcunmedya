using Entity.Enums;

namespace Entity.Entities
{
    public class Bootcamp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BootcampState BootcampState { get; set; }
    }
}
