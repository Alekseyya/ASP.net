using System.Collections.Generic;
using WebStore.Domain.Entities;

namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebStore.DAL.Context.WebStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebStore.DAL.Context.WebStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.AddOrUpdate(r => r.Id,
                new Role
                {
                    Id = 1,
                    Name = "�������������"
                },

                new Role
                {
                    Id = 2,
                    Name = "�����"
                },

                new Role
                {
                    Id = 3,
                    Name = "������������"
                });



            context.Positions.AddOrUpdate(p => p.Id,
                new Position
                {
                    Id = 1,
                    Name = "��� ��������"
                },
                new Position
                {
                    Id = 2,
                    Name = "��������"
                },
                new Position
                {
                    Id = 3,
                    Name = "�����������"
                }
                );

            context.Employees.AddOrUpdate(e=>e.Id,
                new Employee
                {
                    Id = 1,
                    Age = 22,
                    FirstName = "�������",
                    LastName = "����",
                    Partonymic = "�������",
                    PositionId = 1
                },

                new Employee
                {
                    Id = 2,
                    Age = 24,
                    FirstName = "��������",
                    LastName = "��������",
                    Partonymic = "������",
                    PositionId = 2
                },

                new Employee
                {
                    Id = 3,
                    Age = 30,
                    FirstName = "����",
                    LastName = "Ҹ���",
                    Partonymic = "�������������",
                    PositionId = 3
                }
                );
 
            context.Users.AddOrUpdate(u=>u.Id,
                new User
                {
                    Login = "admin",
                    Password = "12345",
                    RoleId = 1
                },
                new User
                {
                    Login = "user",
                    Password = "12345",
                    RoleId = 3
                },
                 new User
                 {
                     Login = "guist",
                     Password = "12345",
                     RoleId = 2
                 }
                );
            
            
            context.SaveChanges();
        }
    }
}
