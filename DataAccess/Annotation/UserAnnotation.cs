using Volunteer.Dto.Models;
using Microsoft.EntityFrameworkCore;

namespace Volunteer.DataAccess.Annotation
{
    internal class UserAnnotation : BaseEntityAnnotation<User>
    {
        internal UserAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => e.Id);
            ModelBuilder.Property(e => e.Id).ValueGeneratedOnAdd().UseIdentityColumn();
            ModelBuilder.Property(e => e.Name).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.NickName).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.Phone_Number).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.Email).IsRequired().HasMaxLength(50);
            ModelBuilder.Property(e => e.Password).IsRequired().HasMaxLength(20);
            ModelBuilder.Property(e => e.MidName).IsRequired().HasMaxLength(30);
            ModelBuilder.Property(e => e.Surname).IsRequired().HasMaxLength(30);
            ModelBuilder.HasMany(e => e.Requests).WithOne(u => u.User).HasForeignKey(e => e.UserId).IsRequired(false);
            ModelBuilder.Property(e => e.Role).IsRequired();
            ModelBuilder.Property(e => e.CreatedBy).IsRequired();
            ModelBuilder.Property(e => e.CreatedDate).IsRequired();
            ModelBuilder.Property(e => e.ModifiedBy);
            ModelBuilder.Property(e => e.ModifiedDate);
        }
    }
}
