using Microsoft.EntityFrameworkCore;
using RegistroDEeTecnico.DAL;
using RegistroDEeTecnico.Models;
using System.Linq.Expressions;

namespace RegistroDEeTecnico.Services
{
    public class TecnicosServices
    {
        private readonly Contexto _context;

        public TecnicosServices(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int tecnicoid)
        {
            return await _context.Tecnicos
            .AnyAsync(p => p.TecnicoId == tecnicoid);
        }

        public async Task<bool> Insertar(Tecnicos tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Tecnicos tecnico)
        {
            _context.Tecnicos.Update(tecnico);
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
            var tecnicos = await _context.Tecnicos.
                Where(P => P.TecnicoId == id).ExecuteDeleteAsync();
            return tecnicos > 0;
        }

        public async Task<Tecnicos?> Buscar(int tecnicoId)
        {
            return _context.Tecnicos
                .AsNoTracking()
                .FirstOrDefault(s => s.TecnicoId == tecnicoId);
        }

        public List<Tecnicos> Listar(Expression<Func<Tecnicos, bool>> Criterio)
        {
            return _context.Tecnicos
                .Where(Criterio)
                .AsNoTracking()
                .ToList();
        }

    }
}
