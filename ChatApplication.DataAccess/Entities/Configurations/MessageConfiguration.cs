using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.DataAccess.Entities.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("messages")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Messages)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .HasColumnName("create_date")
                .HasColumnType("TIME WITH TIME ZONE")
                .IsRequired();

            builder.Property(x => x.IsRead)
                .HasColumnName("is_read")
                .HasColumnType("boolean")
                .IsRequired();

            builder.Property(x => x.Text)
                .HasColumnType("text")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
