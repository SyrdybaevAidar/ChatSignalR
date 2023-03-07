using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatApplication.DataAccess.Entities.Configurations
{
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.ToTable("chats")
                .HasKey(p => p.Id);

            builder.HasMany(x => x.Users)
                .WithMany(x => x.Chats)
                .UsingEntity(x => x.ToTable("users_chats"));

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id")
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.ChatType)
                .HasColumnName("type")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
