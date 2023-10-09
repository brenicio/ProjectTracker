using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;

namespace ProjectTracker.Repository
{
    public class LogAreaRepository : ILogAreaRepository
    {
        private readonly BancoContext _bancoContext;

        public LogAreaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void AddLogArea(LogArea area)
        {
            throw new NotImplementedException();
        }

        public void AddLogAreaEmpresa(LogArea area)
        {
            throw new NotImplementedException();
        }

        public void AddLogAreaEmpresa(ProcessoUsuario processo)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAreaInicio(ProcessoUsuario processo)
        {
            try
            {
                TimeSpan? diferencaTempo;
                LogArea logArea = new();

                var resultIdArea = await _bancoContext.Processos.AsNoTracking().FirstAsync(x => x.Id == processo.IdProcesso);
                var idArea = resultIdArea.IdArea;
                var processoIniciado = await (from pu in _bancoContext.ProcessosUsuario
                                              join p in _bancoContext.Processos on pu.IdProcesso equals p.Id
                                              where pu.AtvItv == 0 && p.IdArea == idArea && pu.Status == "INICIO" && pu.IdEmpresa == processo.IdEmpresa
                                              select new
                                              {
                                                  ProcessosUsuario = pu,
                                                  Processos = p
                                              }
                                       ).FirstOrDefaultAsync();

                if(processoIniciado == null)
                {
                    var logAreaPausado = await _bancoContext.LogAreas
                        .Where(x => x.IdArea == idArea)
                        .Where(d => d.Status.Equals("PAUSA"))
                        .Where(i => i.DataFim == null)
                        .Where(e => e.IdEmpresa == processo.IdEmpresa)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    var logAreaIniciado = await _bancoContext.LogAreas
                        .Where(x => x.IdArea == idArea)
                        .Where(d => d.Status.Equals("INICIO"))
                        .Where(i => i.DataFim == null)
                        .Where(e => e.IdEmpresa == processo.IdEmpresa)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    if (logAreaPausado != null)
                    {
                        logAreaPausado.DataFim = DateTime.Now;
                        logAreaPausado.DataFim = logAreaPausado.DataFim.Value.AddTicks(-(logAreaPausado.DataFim.Value.Ticks % TimeSpan.TicksPerSecond));
                        diferencaTempo = logAreaPausado.DataFim - logAreaPausado.DataInicio;
                        logAreaPausado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;
                        

                        _bancoContext.LogAreas.Entry(logAreaPausado).State = EntityState.Modified;
                        await _bancoContext.SaveChangesAsync();


                        var resultDataFim = await _bancoContext.LogAreas
                                                .AsNoTracking()
                                                .Where(i => i.Id == logAreaPausado.Id)
                                                .FirstOrDefaultAsync();

                        DateTime? DataFimLogAreaPausado = resultDataFim?.DataFim;


                        if (DataFimLogAreaPausado != null && logAreaIniciado == null)
                        {
                            logArea.IdArea = idArea;
                            logArea.IdEmpresa = processo.IdEmpresa;
                            logArea.Status = "INICIO";
                            logArea.DataInicio = logAreaPausado.DataFim;  //SE EXISTE LOG DE AREA PAUSADO SEM FIM, ENTAO ADICIONA O FIM AO INICIO DO PROXIMO LOG A SER INICIADO.
                            logArea.DataCadastro = DateTime.Now;

                            _bancoContext.LogAreas.Entry(logArea).State = EntityState.Added;
                            await _bancoContext.LogAreas.AddAsync(logArea);
                            await _bancoContext.SaveChangesAsync();
                        }

                    }  
                    else if (logAreaIniciado == null)
                    {
                        logArea.IdArea = idArea;
                        logArea.IdEmpresa = processo.IdEmpresa;
                        logArea.Status = "INICIO";
                        logArea.DataInicio = processo.DataInicial;
                        logArea.DataCadastro = DateTime.Now;

                        _bancoContext.LogAreas.Entry(logArea).State = EntityState.Added;
                        await _bancoContext.LogAreas.AddAsync(logArea);
                        await _bancoContext.SaveChangesAsync();
                    }
                }


                //var logAreaPausado = await _bancoContext.LogAreas
                //    .Where(x => x.IdArea == idArea)
                //    .Where(d => d.Status.Equals("PAUSA"))
                //    .Where(i => i.DataFim == null)
                //    .Where(e => e.IdEmpresa == processo.IdEmpresa)
                //    .FirstOrDefaultAsync();

                //var logAreaIniciado = await _bancoContext.LogAreas
                //    .Where(x => x.IdArea == idArea)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .Where(i => i.DataFim == null)
                //    .Where(e => e.IdEmpresa == processo.IdEmpresa)
                //    .FirstOrDefaultAsync();

                //if (logAreaPausado != null && processoIniciado == null)
                //{
                //    logAreaPausado.DataFim = DateTime.Now;
                //    logAreaPausado.DataFim = logAreaPausado.DataFim.Value.AddTicks(-(logAreaPausado.DataFim.Value.Ticks % TimeSpan.TicksPerSecond));
                //    diferencaTempo = logAreaPausado.DataFim - logAreaPausado.DataInicio;
                //    logAreaPausado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                //    ////PARA CASO ACONTEÇA DE TER UM PROCESSO INICIADO SEM FIM
                //    //if (logAreaIniciado != null)
                //    //{
                //    //    logAreaIniciado.DataFim = logAreaPausado.DataInicio;
                //    //    diferencaTempo = logAreaIniciado.DataFim - logAreaIniciado.DataInicio;
                //    //    logAreaIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;
                //    //    _bancoContext.LogAreas.Entry(logAreaIniciado).State = EntityState.Modified;
                //    //    _bancoContext.SaveChanges();
                //    //}

                //    logArea.DataInicio = logAreaPausado.DataFim;  //SE EXISTE LOG DE AREA PAUSADO SEM FIM, ENTAO ADICIONA O FIM AO INICIO DO PROXIMO LOG A SER INICIADO.

                //    _bancoContext.LogAreas.Entry(logAreaPausado).State = EntityState.Modified;
                //    await _bancoContext.SaveChangesAsync();
                //}
                //else if (processoIniciado == null)
                //{
                //    logArea.DataInicio = processo.DataInicial;  //CASO NAO EXISTA LOG DE AREA PAUSADO SEM FIM, PEGUE A DATA INICIAL DO PROCESSO USUARIO;
                //}

                //if (processoIniciado == null && logAreaIniciado == null)
                //{
                //    logArea.IdArea = idArea;
                //    logArea.IdEmpresa = processo.IdEmpresa;
                //    logArea.Status = "INICIO";
                //    logArea.DataCadastro = DateTime.Now;

                //    _bancoContext.LogAreas.Entry(logArea).State = EntityState.Added;
                //    await _bancoContext.LogAreas.AddAsync(logArea);
                //    await _bancoContext.SaveChangesAsync();
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddLogAreaPausa(ProcessoUsuario processo)
        {
            try
            {
                TimeSpan? diferencaTempo;
                LogArea logArea = new();

                var resultIdArea = await _bancoContext.Processos.AsNoTracking().FirstAsync(x => x.Id == processo.IdProcesso);
                var idArea = resultIdArea.IdArea;
                var processoIniciado = await (from pu in _bancoContext.ProcessosUsuario
                                              join p in _bancoContext.Processos on pu.IdProcesso equals p.Id
                                              where pu.AtvItv == 0 && p.IdArea == idArea && pu.Status == "INICIO" && pu.IdEmpresa == processo.IdEmpresa
                                              select new
                                              {
                                                  ProcessosUsuario = pu,
                                                  Processos = p
                                              }
                                       ).FirstOrDefaultAsync();

                if (processoIniciado == null)
                {
                    var logAreaIniciado = await _bancoContext.LogAreas
                        .Where(x => x.IdArea == idArea)
                        .Where(d => d.Status.Equals("INICIO"))
                        .Where(i => i.DataFim == null)
                        .Where(e => e.IdEmpresa == processo.IdEmpresa)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    var logAreaPausado = await _bancoContext.LogAreas
                        .Where(x => x.IdArea == idArea)
                        .Where(d => d.Status.Equals("PAUSA"))
                        .Where(i => i.DataFim == null)
                        .Where(e => e.IdEmpresa == processo.IdEmpresa)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    if (logAreaIniciado != null)
                    {
                        logAreaIniciado.DataFim = processo.DataMovimento;
                        diferencaTempo = logAreaIniciado.DataFim - logAreaIniciado.DataInicio;
                        logAreaIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                        _bancoContext.LogAreas.Entry(logAreaIniciado).State = EntityState.Modified;
                        await _bancoContext.SaveChangesAsync();

                        var resultDataFim = await _bancoContext.LogAreas
                                            .AsNoTracking()
                                            .Where(i => i.Id == logAreaIniciado.Id)
                                            .FirstOrDefaultAsync();

                        DateTime? DataFimLogAreaInicio = resultDataFim?.DataFim;

                        if (DataFimLogAreaInicio != null && logAreaPausado == null)
                        {
                            logArea.IdArea = idArea;
                            logArea.IdEmpresa = processo.IdEmpresa;
                            logArea.Status = "PAUSA";
                            logArea.DataInicio = processo.DataMovimento;
                            logArea.DataCadastro = DateTime.Now;

                            _bancoContext.LogAreas.Entry(logArea).State = EntityState.Added;
                            await _bancoContext.LogAreas.AddAsync(logArea);
                            await _bancoContext.SaveChangesAsync();
                        }
                    }                 

                    
                }

                //var logAreaIniciado = await _bancoContext.LogAreas
                //    .Where(x => x.IdArea == idArea)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .Where(i => i.DataFim == null)
                //    .Where(e => e.IdEmpresa == processo.IdEmpresa)
                //    .FirstOrDefaultAsync();

                //var logAreaPausado = await _bancoContext.LogAreas
                //    .Where(x => x.IdArea == idArea)
                //    .Where(d => d.Status.Equals("PAUSA"))
                //    .Where(i => i.DataFim == null)
                //    .Where(e => e.IdEmpresa == processo.IdEmpresa)
                //    .FirstOrDefaultAsync();

                //if (logAreaIniciado != null && processoIniciado == null)
                //{
                //    logAreaIniciado.DataFim = processo.DataMovimento;
                //    diferencaTempo = logAreaIniciado.DataFim - logAreaIniciado.DataInicio;
                //    logAreaIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                //    _bancoContext.LogAreas.Entry(logAreaIniciado).State = EntityState.Modified;
                //    await _bancoContext.SaveChangesAsync();

                //}

                //if (processoIniciado == null && logAreaPausado == null)
                //{
                //    logArea.IdArea = idArea;
                //    logArea.IdEmpresa = processo.IdEmpresa;
                //    logArea.Status = "PAUSA";
                //    logArea.DataInicio = processo.DataMovimento;
                //    logArea.DataCadastro = DateTime.Now;

                //    _bancoContext.LogAreas.Entry(logArea).State = EntityState.Added;
                //    await _bancoContext.LogAreas.AddAsync(logArea);
                //    await _bancoContext.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LogArea? GetLogAreaById(int idArea)
        {
            try
            {
                var log = _bancoContext.LogAreas.FirstOrDefault(x => x.Id == idArea);
                return log;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLogArea(LogArea area)
        {
            throw new NotImplementedException();
        }
    }
}
