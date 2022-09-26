using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingAppAPI.DTOs;
using DatingAppAPI.Entities;
using DatingAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DatingAppAPI.Data
{
    public class UserRepository : IUserReporsitory

    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            //Without using automapper This was the case we have to write all theproperties
            // AutoMapper gives us equivalent of this property and allows us to project inside our
            //   repository and its only going to select the properties that we actually need 
            /*return await _context.Users.Where(x => x.UserName == username)
                .Select(user => new MemberDto
                {
                    Id = user.Id,

                    and write 20 other properties

                }).SingleOrDefaultAsync();*/
            return await _context.Users
               .Where(x => x.UserName == username)
               .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync();
               //From here we can provide configurationprofile through automapper profile we created
               }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                 .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(p=>p.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;  
        }
    }
}
