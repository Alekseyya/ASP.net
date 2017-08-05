using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.DAL.Repositories.Base;
using WebStore.Domain.DataContracts.Service;
using WebStore.Domain.Entities;
using WebStore.Services.Services.Base;

namespace WebStore.Services.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        #region Group
        public void DeleteGroup(int id)
        {
            _unitOfWork.GroupRepository.Delete(id);
        }

        public GroupDataContract GetGroupById(int id)
        {
            Mapper.Initialize(o => o.CreateMap<Group, GroupDataContract>());
            var group = Mapper.Map<Group, GroupDataContract>(_unitOfWork.GroupRepository.GetItem(id));
            return group;
        }

        public IEnumerable<GroupDataContract> GetGroups()
        {
            Mapper.Initialize(o => o.CreateMap<Group, GroupDataContract>());
            var groups = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDataContract>>(_unitOfWork.GroupRepository.GetList());
            return groups.ToArray();
        }

        public bool RegisterUser(string userName, string userPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(userPassword);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var user = _unitOfWork.UserRepository.GetItemByName(userName);
            if (user != null)
                return false;
            return _unitOfWork.AuthenticationRepository.RegisterUser(new Domain.Entities.User
            {
                GroupId = 2,
                IsDeleted = false,
                Name = userName,
                Password = passwordBase64
            });
        }

        public void UpdateGroup(GroupDataContract group)
        {
            Mapper.Initialize(o => o.CreateMap<GroupDataContract, Group>());
            var groupUpdate = Mapper.Map<GroupDataContract, Group>(group);
            _unitOfWork.GroupRepository.Update(groupUpdate);
        }

        public bool UserInGroup(string userName, string groupName)
        {
            var user = _unitOfWork.UserRepository.GetItemByName(userName);
            var group = _unitOfWork.GroupRepository.GetItem(user.GroupId);
            if (group != null && group.Name == groupName)
            {
                return true;
            }
            return false;
        } 
        #endregion

        #region User
        public UserDataContract GetUser(string name)
        {
            Mapper.Initialize(o => o.CreateMap<User, UserDataContract>()
                    .ForMember("Group", u => u.MapFrom(us => us.Group.Name)));
            var user = Mapper.Map<User, UserDataContract>(_unitOfWork.UserRepository.GetItemByName(name));
            return user;
        }

        public UserDataContract GetUser(int id)
        {
            Mapper.Initialize(o => o.CreateMap<User, UserDataContract>()
            .ForMember("Group", u => u.MapFrom(us => us.Group.Name)));
            var user = Mapper.Map<User, UserDataContract>(_unitOfWork.UserRepository.GetItem(id));
            return user;
        }

        public IEnumerable<UserDataContract> GetUsers()
        {
            Mapper.Initialize(o => o.CreateMap<User, UserDataContract>()
                .ForMember("Group", u => u.MapFrom(us => us.Group.Name)));
            var users = Mapper.Map<IEnumerable<User>, IEnumerable<UserDataContract>>(_unitOfWork.UserRepository.GetList());
            return users.ToArray();
        }

        public bool RestoreUser(int id)
        {
            throw new NotImplementedException();
        }
        public bool AddUser(UserDataContract user)
        {
            Mapper.Initialize(o => o.CreateMap<UserDataContract, User>());
            var userNew = Mapper.Map<UserDataContract, User>(user);
            _unitOfWork.UserRepository.Create(userNew);
            return true;
        }

        public bool DeleteUser(int id)
        {
            _unitOfWork.UserRepository.Delete(id);
            return true;
        }

        public bool EditUser(UserDataContract user)
        {
            Mapper.Initialize(o => o.CreateMap<UserDataContract, User>()
            .ForMember("Group", op=>op.Ignore()));
            var userNew = Mapper.Map<UserDataContract, User>(user);
            userNew.GroupId = _unitOfWork.GroupRepository.GetList().FirstOrDefault(u => u.Name == user.Group).Id;
            _unitOfWork.UserRepository.Update(userNew);
            return true;
        }

        public bool CheckUser(string userName, string userPassword)
        {
            var bytes = Encoding.UTF8.GetBytes(userPassword);
            var passwordBase64 = Convert.ToBase64String(bytes, 0, bytes.Length);
            var user = _unitOfWork.UserRepository.GetItemByName(userName);
            if (user == null)
                return false;
            return user.Password == passwordBase64;
        }
        #endregion
    }
}
