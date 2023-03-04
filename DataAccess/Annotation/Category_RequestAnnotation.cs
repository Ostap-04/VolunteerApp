using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer.Dto.Models;

namespace Volunteer.DataAccess.Annotation
{
    internal class Category_RequestAnnotation : BaseEntityAnnotation<Category_Request>
    {
        internal Category_RequestAnnotation(Microsoft.EntityFrameworkCore.ModelBuilder builder)
            : base(builder)
        {
        }

        public override void Annotate()
        {
            ModelBuilder.HasKey(e => new { e.CategoryId, e.RequestId });
            ModelBuilder.HasOne<Category>(e => e.Category).WithMany(e => e.Category_Requests).HasForeignKey(e => e.CategoryId);
            ModelBuilder.HasOne<Request>(e => e.Request).WithMany(e => e.Category_Requests).HasForeignKey(e => e.RequestId);
        }
    }
}
