﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebExpress.WebCore;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebApp.WebUser
{
    public static class UserManager
    {
        /// <summary>
        /// Returns or sets the reference to the context of the host.
        /// </summary>
        private static IHttpServerContext Context { get; set; }

        /// <summary>
        /// Returns or sets the root directory where the user data is located.
        /// </summary>
        private static string UserRootPath { get; set; }

        /// <summary>
        /// Returns the registered users.
        /// </summary>
        public static ICollection<User> Users { get; } = new List<User>();

        /// <summary>
        /// Returns the registered groups.
        /// </summary>
        public static ICollection<Group> Groups { get; } = new List<Group>();

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The reference to the context of the host.</param>
        internal static void Initialization(IHttpServerContext context)
        {
            Context = context;

            UserRootPath = Path.Combine(context.DataPath, "usermanager");

            LoadGroup();
            LoadUser();

            Context.Log.Info(message: I18N("webexpress.webapp:usermanager.initialization"));
        }

        /// <summary>
        /// Load all users from the file system.
        /// </summary>
        private static void LoadUser()
        {
            var path = Path.Combine(UserRootPath, "users");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var files = Directory.GetFiles(path, "*.xml");
            var serializer = new XmlSerializer(typeof(User));
            foreach (var file in files)
            {
                try
                {
                    using var reader = File.OpenText(file);
                    Users.Add(serializer.Deserialize(reader) as User);
                }
                catch (Exception ex)
                {
                    Context.Log.Exception(ex);
                }
            }
        }

        /// <summary>
        /// Adds a new user.
        /// </summary>
        /// <param name="user">The new user.</param>
        public static void AddUser(User user)
        {
            UpdateUser(user);

            Users.Add(user);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="user">The existing user.</param>
        public static void UpdateUser(User user)
        {
            var serializer = new XmlSerializer(typeof(User));
            var xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            user.Updated = DateTime.Now;

            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, user, xmlns);

                var utf = new UTF8Encoding();
                var fileName = Path.Combine(UserRootPath, "users", string.Format("{0}.xml", user.Id));

                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                File.WriteAllText
                (
                    fileName,
                    utf.GetString(memoryStream.ToArray())
                );

                Context.Log.Info(message: I18N("webexpress.webapp:usermanager.user.save"), args: $"{user.Lastname}, {user.Firstname}");
            }
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="user">The user to be deleted.</param>
        public static void RemoveUser(User user)
        {
            var fileName = Path.Combine(UserRootPath, "users", string.Format("{0}.xml", user.Id));

            Users.Remove(user);
            File.Delete(fileName);

            Context.Log.Info(message: I18N("webexpress.webapp:usermanager.user.delete"), args: user.Login);
        }

        /// <summary>
        /// Load all groups from file system.
        /// </summary>
        private static void LoadGroup()
        {
            var path = Path.Combine(UserRootPath, "groups");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var files = Directory.GetFiles(path, "*.xml");
            var serializer = new XmlSerializer(typeof(Group));
            foreach (var file in files)
            {
                try
                {
                    using var reader = File.OpenText(file);
                    Groups.Add(serializer.Deserialize(reader) as Group);
                }
                catch (Exception ex)
                {
                    Context.Log.Exception(ex);
                }
            }
        }

        /// <summary>
        /// Adds a new group.
        /// </summary>
        /// <param name="group">The new group.</param>
        public static void AddGroup(Group group)
        {
            UpdateGroup(group);

            Groups.Add(group);
        }

        /// <summary>
        /// Updates an existing group.
        /// </summary>
        /// <param name="group">The existing group.</param>
        public static void UpdateGroup(Group group)
        {
            var serializer = new XmlSerializer(typeof(Group));
            var xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            group.Updated = DateTime.Now;

            using (var memoryStream = new MemoryStream())
            {
                serializer.Serialize(memoryStream, group, xmlns);

                var utf = new UTF8Encoding();
                var fileName = Path.Combine(UserRootPath, "groups", string.Format("{0}.xml", group.Id));

                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }

                File.WriteAllText
                (
                    fileName,
                    utf.GetString(memoryStream.ToArray())
                );

                Context.Log.Info(message: I18N("webexpress.webapp:usermanager.group.save"), args: group.Name);
            }
        }

        /// <summary>
        /// Deletes a group. 
        /// </summary>
        /// <param name="group">The group to be deleted.</param>
        public static void RemoveGroup(Group group)
        {
            var fileName = Path.Combine(UserRootPath, "groups", string.Format("{0}.xml", group.Id));

            Parallel.ForEach(Users, i =>
            {
                if (i.GroupIds.Contains(group?.Id))
                {
                    i.GroupIds.Remove(group?.Id);
                    UpdateUser(i);
                }
            });

            Groups.Remove(group);
            File.Delete(fileName);

            Context.Log.Info(message: I18N("webexpress.webapp:usermanager.group.delete"), args: group.Name);
        }
    }
}
