using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Entity;
using RepositoryLayer.FundooNotesContext;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CollabRL : ICollabRL
    {
        FundooContext fundoo;
        public IConfiguration Configuration { get; }

        //Creating constructor for initialization
        public CollabRL(FundooContext fundoo, IConfiguration configuration)
        {
            this.fundoo = fundoo;
            this.Configuration = configuration;
        }

        public async Task<Collaborator> AddCollaborator(int userId, int NoteId, CollaboratorValidation collab)
        {
            try
            {
                var user = fundoo.Users.FirstOrDefault(u => u.UserId == userId);
                var note = fundoo.Notes.FirstOrDefault(b => b.NoteId == NoteId);
                Collaborator collaborator = new Collaborator
                {
                    User = user,
                    Note = note
                };
                collaborator.CollabEmail = collab.email;
                fundoo.Collaborators.Add(collaborator);
                await fundoo.SaveChangesAsync();
                return collaborator;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> RemoveCollaborator(int userId, int NoteId, int collaboratorId)
        {
            try
            {
                var result = fundoo.Collaborators.FirstOrDefault(u => u.userId == userId && u.NoteId == NoteId && u.collaboratorId == collaboratorId);
                if (result != null)
                {
                    fundoo.Collaborators.Remove(result);
                    await fundoo.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Collaborator>> GetCollaboratorByUserId(int userId)
        {
            try
            {
                List<Collaborator> result = await fundoo.Collaborators.Where(u => u.userId == userId).Include(u => u.User).Include(U => U.Note).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Collaborator>> GetCollaboratorByNoteId(int userId, int NoteId)
        {
            try
            {
                List<Collaborator> result = await fundoo.Collaborators.Where(u => u.userId == userId && u.NoteId == NoteId).Include(u => u.User).Include(U => U.Note).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
