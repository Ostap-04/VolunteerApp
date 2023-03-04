using Volunteer.Dto.Models;

namespace Volunteer.DataAccess.Annotation
{
    internal class UserAnnotation : BaseEntityAnnotation<User>
    {
        internal UserAnnotation(Microsoft.EntityFrameworkCore.ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => e.Id);
            ModelBuilder.Property(e => e.Id).ValueGeneratedNever();
            ModelBuilder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.MidName).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.Surname).IsRequired().HasMaxLength(30);
            ModelBuilder.HasMany<Request>(e => e.Requests).WithOne(u => u.User).HasForeignKey(g => g.UserId);
            ModelBuilder.Property(e => e.Role).IsRequired();
        }
    }
}
