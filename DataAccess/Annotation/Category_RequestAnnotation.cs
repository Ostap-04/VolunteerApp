using Microsoft.EntityFrameworkCore;
using Volunteer.Dto.Models;

namespace Volunteer.DataAccess.Annotation
{
    internal class Category_RequestAnnotation : BaseEntityAnnotation<Category_Request>
    {
        internal Category_RequestAnnotation(ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => new { e.CategoryId, e.RequestId });
            ModelBuilder.HasOne(e => e.Category).WithMany(e => e.Category_Requests).HasForeignKey(e => e.CategoryId);
            ModelBuilder.HasOne(e => e.Request).WithMany(e => e.Category_Requests).HasForeignKey(e => e.RequestId);
        }
    }
}
