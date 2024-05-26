using Microsoft.EntityFrameworkCore;
using RegistroDEeTecnico.DAL;
using RegistroDEeTecnico.Models;
using System.Linq.Expressions;

namespace RegistroDEeTecnico.Services
{
    public class TipoTecnicosService
    {
        private readonly Contexto _context;

        public TipoTecnicosService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Existe(int tipoId)
        {
            return await _context.TiposTecnicos.AnyAsync(t => t.tipoId == tipoId);
        }

        public async Task<bool> Existe(string descripcion)
        {
            return await _context.TiposTecnicos.AnyAsync(t => t.Descripcion == descripcion);
        }

        private async Task<bool> Insertar(TiposTecnicos tiposTecnico)
        {
            _context.TiposTecnicos.Add(tiposTecnico);
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(TiposTecnicos tiposTecnico)
        {
            _context.TiposTecnicos.Update(tiposTecnico);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(TiposTecnicos tipostecnico)
        {
            if (!await Existe(tipostecnico.tipoId))
                return await Insertar(tipostecnico);
            else
                return await Modificar(tipostecnico);
        }

        public async Task<bool> Eliminar(int id)
        {
            var tipostecnico = await _context.TiposTecnicos
                .Where(t => t.tipoId == id)
                .ExecuteDeleteAsync();
            return tipostecnico > 0;
        }

        public async Task<TiposTecnicos?> Buscar(int tipoId)
        {
            return await _context.TiposTecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.tipoId == tipoId);
        }

        public async Task<List<TiposTecnicos>> Listar(Expression<Func<TiposTecnicos, bool>> criterio)
        {
            return await _context.TiposTecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
