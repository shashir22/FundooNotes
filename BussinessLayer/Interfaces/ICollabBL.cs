﻿using DatabaseLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ICollabBL
    {
        Task<Collaborator> AddCollaborator(int userId, int NoteId, CollaboratorValidation collab);
        Task<bool> RemoveCollaborator(int userId, int NoteId, int collaboratorId);
        Task<List<Collaborator>> GetCollaboratorByUserId(int userId);
        Task<List<Collaborator>> GetCollaboratorByNoteId(int userId, int NoteId);
    }
}
