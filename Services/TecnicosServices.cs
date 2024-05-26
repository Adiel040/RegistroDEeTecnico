using Microsoft.EntityFrameworkCore;
using RegistroDEeTecnico.DAL;
using RegistroDEeTecnico.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RegistroDEeTecnico.Services
{
    public class TecnicosServices
    {
        private readonly Contexto _context;

        public TecnicosServices(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int TecnicoId)
        {
            return await _context.Tecnicos
                .AnyAsync(t => t.TecnicoId == TecnicoId);
        }

        private async Task<bool> Insertar(Tecnicos tecnicos)
        {
            _context.Tecnicos.Add(tecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tecnicos tecnicos)
        {
            _context.Tecnicos.Update(tecnicos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Tecnicos tecnico)
        {
            if (!await Existe(tecnico.TecnicoId))
                return await Insertar(tecnico);
            else
                return await Modificar(tecnico);
        }

        public async Task<bool> Eliminar(int id)
        {
            var tecnicos = await _context.Tecnicos
                .Where(t => t.TecnicoId == id)
                .ExecuteDeleteAsync();
            return tecnicos > 0;
        }

        public async Task<Tecnicos?> Buscar(int TecnicoId)
        {
            return await _context.Tecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TecnicoId == TecnicoId);
        }

        public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> Criterio)
        {
            return await _context.Tecnicos
                .AsNoTracking()
                .Where(Criterio)
                .ToListAsync();
        }
    }
}
