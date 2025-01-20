using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    public class MemberController
    {
        private readonly LibraryDbContext _context;

        public MemberController()
        {
            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseSqlServer("Server=localhost;Database=LibraryDB;Trusted_Connection=True;")
                .Options;
            _context = new LibraryDbContext(options);
        }

        public Member Login(string membershipId, string password)
        {
            return _context.Members.FirstOrDefault(m => m.MembershipID == membershipId && m.Password == password);
        }
        // Add a new member
        public void AddMember(Member member)
        {
            if (_context.Members.Any(m => m.MembershipID == member.MembershipID))
            {
                throw new Exception("Membership ID already exists.");
            }
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        // Update an existing member
        public void UpdateMember(Member member)
        {
            var existingMember = _context.Members.Find(member.MemberId);
            if (existingMember != null)
            {
                existingMember.Name = member.Name;
                existingMember.MembershipID = member.MembershipID;
                existingMember.Password = member.Password;
                existingMember.PhoneNumber = member.PhoneNumber;
                existingMember.Address = member.Address;

                _context.Members.Update(existingMember);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found.");
            }
        }

        // Delete a member by ID
        public void DeleteMember(int memberId)
        {
            var member = _context.Members.Find(memberId);
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found.");
            }
        }

        // Retrieve all members
        public List<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }
    }
}
