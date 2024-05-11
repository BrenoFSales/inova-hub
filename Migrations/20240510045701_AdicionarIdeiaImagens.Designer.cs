﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using aspnet2.Models;

#nullable disable

namespace aspnet2.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240510045701_AdicionarIdeiaImagens")]
    partial class AdicionarIdeiaImagens
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("comment_id_seq")
                .HasMax(2147483647L);

            modelBuilder.HasSequence("idea_id_seq")
                .HasMax(2147483647L);

            modelBuilder.HasSequence("post_id_seq")
                .HasMax(2147483647L);

            modelBuilder.HasSequence("user_id_seq")
                .HasMax(2147483647L);

            modelBuilder.Entity("aspnet2.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("integer")
                        .HasColumnName("post_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("comment_pkey");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.Favorite", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("integer")
                        .HasColumnName("id_user");

                    b.Property<int>("IdIdea")
                        .HasColumnType("integer")
                        .HasColumnName("id_idea");

                    b.Property<DateOnly>("FavoriteDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("favorite_date")
                        .HasDefaultValueSql("CURRENT_DATE")
                        .HasComment("vai automaticamente gerar data atual quando linha for inserida");

                    b.HasKey("IdUser", "IdIdea")
                        .HasName("favorite_pk");

                    b.HasIndex("IdIdea");

                    b.ToTable("favorite", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.Idea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdUser")
                        .HasColumnType("integer")
                        .HasColumnName("id_user");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("idea_pk");

                    b.HasIndex("IdUser");

                    b.ToTable("idea", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.Image", b =>
                {
                    b.Property<string>("Url")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("url");

                    b.Property<int>("IdeaId")
                        .HasColumnType("integer")
                        .HasColumnName("idea_id");

                    b.HasKey("Url")
                        .HasName("image_pkey");

                    b.HasIndex("IdeaId");

                    b.ToTable("image", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.Post", b =>
                {
                    b.Property<int>("IdeaId")
                        .HasColumnType("integer")
                        .HasColumnName("idea_id");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<string>("Text")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)")
                        .HasColumnName("text");

                    b.HasKey("IdeaId", "Id")
                        .HasName("post_pkey");

                    b.HasIndex(new[] { "Id" }, "post_id_key")
                        .IsUnique();

                    b.ToTable("post", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.Upvote", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("IdIdea")
                        .HasColumnType("integer")
                        .HasColumnName("id_idea");

                    b.Property<DateOnly?>("UpvoteDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date")
                        .HasColumnName("upvote_date")
                        .HasDefaultValueSql("CURRENT_DATE")
                        .HasComment("vai automaticamente gerar data atual quando linha for inserida");

                    b.HasKey("UserId", "IdIdea")
                        .HasName("upvote_pk");

                    b.HasIndex("IdIdea");

                    b.ToTable("upvote", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("character varying(32)")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("user_pkey");

                    b.HasIndex(new[] { "Name" }, "user_name_key")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("aspnet2.Models.Comment", b =>
                {
                    b.HasOne("aspnet2.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .HasPrincipalKey("Id")
                        .IsRequired()
                        .HasConstraintName("comment_post_id_fkey");

                    b.HasOne("aspnet2.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("comment_user_id_fkey");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("aspnet2.Models.Favorite", b =>
                {
                    b.HasOne("aspnet2.Models.Idea", "IdIdeaNavigation")
                        .WithMany("Favorites")
                        .HasForeignKey("IdIdea")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("idea_fk");

                    b.HasOne("aspnet2.Models.User", "IdUserNavigation")
                        .WithMany("Favorites")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("user_fk");

                    b.Navigation("IdIdeaNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("aspnet2.Models.Idea", b =>
                {
                    b.HasOne("aspnet2.Models.User", "IdUserNavigation")
                        .WithMany("Ideas")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("user_fk");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("aspnet2.Models.Image", b =>
                {
                    b.HasOne("aspnet2.Models.Idea", "Idea")
                        .WithMany("Images")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idea");
                });

            modelBuilder.Entity("aspnet2.Models.Post", b =>
                {
                    b.HasOne("aspnet2.Models.Idea", "Idea")
                        .WithMany("Posts")
                        .HasForeignKey("IdeaId")
                        .IsRequired()
                        .HasConstraintName("post_idea_id_fkey");

                    b.Navigation("Idea");
                });

            modelBuilder.Entity("aspnet2.Models.Upvote", b =>
                {
                    b.HasOne("aspnet2.Models.Idea", "IdIdeaNavigation")
                        .WithMany("Upvotes")
                        .HasForeignKey("IdIdea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("idea_fk");

                    b.HasOne("aspnet2.Models.User", "User")
                        .WithMany("Upvotes")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("upvote_user_id_fkey");

                    b.Navigation("IdIdeaNavigation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("aspnet2.Models.Idea", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Images");

                    b.Navigation("Posts");

                    b.Navigation("Upvotes");
                });

            modelBuilder.Entity("aspnet2.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("aspnet2.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Favorites");

                    b.Navigation("Ideas");

                    b.Navigation("Upvotes");
                });
#pragma warning restore 612, 618
        }
    }
}
