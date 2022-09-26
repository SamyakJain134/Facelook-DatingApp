﻿using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;

namespace DatingAppAPI.Interfaces
{
    public interface IUserReporsitory
    {
        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);  

        Task<IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto> GetMemberAsync(string username);
    }
}
