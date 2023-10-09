using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace ProjectTracker.Repository
{
    public class LogProcessoRepository : ILogProcessoRepository
    {
        private readonly BancoContext _bancoContext;

        public LogProcessoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public void AddLogProcesso(ProcessoUsuario ProcessoUsuario)
        {





            //var logPausa = this.GetLogProcessoByUser(LogProcesso.IdUsuario).Result.Where(c => c.DataInicio != null).Where(d => d.DataFim == null).FirstOrDefault();
            //try
            //{
            //    if(logPausa != null && LogProcesso != null)
            //    {
            //        logPausa.Status = "PAUSA";
            //        logPausa.DataInicio = LogProcesso.DataInicio;
            //        logPausa.DataFim = null;
            //        _bancoContext.LogProcessos.Entry(logPausa).State = EntityState.Added;
            //        _bancoContext.LogProcessos.Add(logPausa);
            //        _bancoContext.SaveChanges();
            //    }

            //    if(LogProcesso != null)
            //    {
            //        _bancoContext.LogProcessos.Entry(LogProcesso).State = EntityState.Added;
            //        _bancoContext.LogProcessos.Add(LogProcesso);
            //        _bancoContext.SaveChanges();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException();
        }
        public Task<List<LogProcesso>> GetLogProcessoByUser(int idUser)
        {
            //try
            //{
            //    var logProcessos = _bancoContext.LogProcessos.Where(c => c.IdUsuario == idUser).ToListAsync();
            //    return logProcessos;
            //} catch(Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            throw new NotImplementedException();
        }
        public async Task AddLogProcessoInicio(ProcessoUsuario ProcessoUsuario)
        {
            try
            {
                LogProcesso logProcesso = new();
                TimeSpan? diferencaTempo;

                var processoIniciado = await _bancoContext.ProcessosUsuario
                                            .Where(i => i.Id == ProcessoUsuario.Id)
                                            .Where(s => s.Status.Equals("INICIO"))
                                            .FirstOrDefaultAsync();

                if(processoIniciado != null)
                {
                    var LogProcessoIniciado = await _bancoContext.LogProcessos
                     .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                     .Where(d => d.Status.Equals("INICIO"))
                     .Where(e => e.DataFim == null)
                     .OrderByDescending(o => o.Id)
                     .FirstOrDefaultAsync();

                    var LogProcessoPausado = await _bancoContext.LogProcessos
                        .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                        .Where(d => d.Status.Equals("PAUSA"))
                        .Where(e => e.DataFim == null)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    if(LogProcessoPausado != null)
                    {
                        LogProcessoPausado.DataFim = DateTime.Now;
                        LogProcessoPausado.DataFim = LogProcessoPausado.DataFim.Value.AddTicks(-(LogProcessoPausado.DataFim.Value.Ticks % TimeSpan.TicksPerSecond));
                        diferencaTempo = LogProcessoPausado.DataFim - LogProcessoPausado.DataInicio;
                        LogProcessoPausado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                        _bancoContext.LogProcessos.Entry(LogProcessoPausado).State = EntityState.Modified;
                        _bancoContext.SaveChanges();

                        var resultDataFim = await _bancoContext.LogProcessos
                                                .AsNoTracking()
                                                .Where(i => i.Id == LogProcessoPausado.Id)
                                                .FirstOrDefaultAsync();

                        DateTime? DataFimLogProcessoPausado = resultDataFim?.DataFim;

                        if(DataFimLogProcessoPausado != null && LogProcessoIniciado == null)
                        {
                            logProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                            logProcesso.Status = "INICIO";
                            logProcesso.DataInicio = LogProcessoPausado.DataFim; //SE EXISTE LOG DE PROCESSO PAUSADO SEM FIM, ENTAO ADICIONA O FIM AO INICIO DO PROXIMO LOG A SER INICIADO.

                            _bancoContext.LogProcessos.Entry(logProcesso).State = EntityState.Added;
                            await _bancoContext.LogProcessos.AddAsync(logProcesso);
                            await _bancoContext.SaveChangesAsync();
                        }
                    } else if(LogProcessoIniciado == null)
                    {
                        logProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                        logProcesso.Status = "INICIO";
                        logProcesso.DataInicio = ProcessoUsuario.DataInicial;  //CASO NAO EXISTA LOG DE PROCESSO PAUSADO SEM FIM, PEGUE A DATA INICIAL DO PROCESSO USUARIO;

                        _bancoContext.LogProcessos.Entry(logProcesso).State = EntityState.Added;
                        await _bancoContext.LogProcessos.AddAsync(logProcesso);
                        await _bancoContext.SaveChangesAsync();
                    }
                }

                //LogProcesso logProcesso = new();
                //TimeSpan? diferencaTempo;


                //var LogProcessoIniciado = await _bancoContext.LogProcessos
                //    .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .Where(e => e.DataFim == null)
                //    .OrderByDescending(o => o.Id)
                //    .FirstOrDefaultAsync();

                //var LogProcessoPausado = await _bancoContext.LogProcessos
                //    .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                //    .Where(d => d.Status.Equals("PAUSA"))
                //    .Where(e => e.DataFim == null)
                //    .OrderByDescending(o => o.Id)
                //    .FirstOrDefaultAsync();

                //if (LogProcessoPausado != null)
                //{
                //    LogProcessoPausado.DataFim = DateTime.Now;
                //    LogProcessoPausado.DataFim = LogProcessoPausado.DataFim.Value.AddTicks(-(LogProcessoPausado.DataFim.Value.Ticks % TimeSpan.TicksPerSecond));
                //    diferencaTempo = LogProcessoPausado.DataFim - LogProcessoPausado.DataInicio;
                //    LogProcessoPausado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                //    //PARA CASO ACONTEÇA DE TER UM PROCESSO INICIADO SEM FIM
                //    if (LogProcessoIniciado != null)
                //    {
                //        LogProcessoIniciado.DataFim = LogProcessoPausado.DataInicio;
                //        diferencaTempo = LogProcessoIniciado.DataFim - LogProcessoIniciado.DataInicio;
                //        LogProcessoIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;
                //        _bancoContext.LogProcessos.Entry(LogProcessoIniciado).State = EntityState.Modified;
                //        _bancoContext.SaveChanges();
                //    }

                //    logProcesso.DataInicio = LogProcessoPausado.DataFim;  //SE EXISTE LOG DE PROCESSO PAUSADO SEM FIM, ENTAO ADICIONA O FIM AO INICIO DO PROXIMO LOG A SER INICIADO.

                //    _bancoContext.LogProcessos.Entry(LogProcessoPausado).State = EntityState.Modified;
                //    _bancoContext.SaveChanges();
                //}
                //else
                //{
                //    logProcesso.DataInicio = ProcessoUsuario.DataInicial;  //CASO NAO EXISTA LOG DE PROCESSO PAUSADO SEM FIM, PEGUE A DATA INICIAL DO PROCESSO USUARIO;
                //}

                //if (ProcessoUsuario != null)
                //{

                //    logProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                //    logProcesso.Status = "INICIO";

                //    _bancoContext.LogProcessos.Entry(logProcesso).State = EntityState.Added;
                //    _bancoContext.LogProcessos.Add(logProcesso);
                //    _bancoContext.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public async Task AddLogProcessoPausa(ProcessoUsuario ProcessoUsuario)
        {
            try
            {
                LogProcesso logProcesso = new();
                TimeSpan? diferencaTempo;

                var processoPausado = await _bancoContext.ProcessosUsuario
                                            .Where(i => i.Id == ProcessoUsuario.Id)
                                            .Where(s => s.Status.Equals("PAUSA"))
                                            .FirstOrDefaultAsync();

                if(processoPausado != null)
                {
                    var LogProcessoIniciado = await _bancoContext.LogProcessos
                        .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                        .Where(d => d.Status.Equals("INICIO"))
                        .Where(e => e.DataFim == null)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    var LogProcessoPausado = await _bancoContext.LogProcessos
                        .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                        .Where(d => d.Status.Equals("PAUSA"))
                        .Where(e => e.DataFim == null)
                        .OrderByDescending(o => o.Id)
                        .FirstOrDefaultAsync();

                    if(LogProcessoIniciado != null)
                    {
                        LogProcessoIniciado.DataFim = ProcessoUsuario.DataMovimento;
                        diferencaTempo = LogProcessoIniciado.DataFim - LogProcessoIniciado.DataInicio;
                        LogProcessoIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                        _bancoContext.LogProcessos.Entry(LogProcessoIniciado).State = EntityState.Modified;
                        await _bancoContext.SaveChangesAsync();

                        var resultDataFim = await _bancoContext.LogProcessos
                                            .AsNoTracking()
                                            .Where(i => i.Id == LogProcessoIniciado.Id)
                                            .FirstOrDefaultAsync();

                        DateTime? DataFimLogProcessoInicio = resultDataFim?.DataFim;

                        if(DataFimLogProcessoInicio != null && LogProcessoPausado == null)
                        {
                            logProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                            logProcesso.Status = "PAUSA";
                            logProcesso.DataInicio = ProcessoUsuario.DataMovimento;

                            _bancoContext.LogProcessos.Entry(logProcesso).State = EntityState.Added;
                            await _bancoContext.LogProcessos.AddAsync(logProcesso);
                            await _bancoContext.SaveChangesAsync();
                        }
                    }
                    else if(LogProcessoPausado == null)
                    {
                        logProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                        logProcesso.Status = "PAUSA";
                        logProcesso.DataInicio = ProcessoUsuario.DataMovimento;

                        _bancoContext.LogProcessos.Entry(logProcesso).State = EntityState.Added;
                        await _bancoContext.LogProcessos.AddAsync(logProcesso);
                        await _bancoContext.SaveChangesAsync();
                    }
                }


                //LogProcesso logProcesso = new();
                //TimeSpan? diferencaTempo;

                //var LogProcessoIniciado = _bancoContext.LogProcessos
                //    .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                //    .Where(d => d.Status.Equals("INICIO"))
                //    .Where(e => e.DataFim == null)
                //    .FirstOrDefault();

                //var LogProcessoPausado = _bancoContext.LogProcessos
                //    .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                //    .Where(d => d.Status.Equals("PAUSA"))
                //    .Where(e => e.DataFim == null)
                //    .FirstOrDefault();

                //if (LogProcessoIniciado != null && ProcessoUsuario != null)
                //{
                //    LogProcessoIniciado.DataFim = ProcessoUsuario.DataMovimento;
                //    diferencaTempo = LogProcessoIniciado.DataFim - LogProcessoIniciado.DataInicio;
                //    LogProcessoIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                //    if(LogProcessoPausado != null)
                //    {
                //        LogProcessoPausado.DataFim = LogProcessoIniciado.DataInicio;
                //        diferencaTempo = LogProcessoPausado.DataFim - LogProcessoPausado.DataInicio;
                //        LogProcessoPausado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;
                //        _bancoContext.LogProcessos.Entry(LogProcessoPausado).State = EntityState.Modified;
                //        _bancoContext.SaveChanges();
                //    }

                //    _bancoContext.LogProcessos.Entry(LogProcessoIniciado).State = EntityState.Modified;
                //    _bancoContext.SaveChanges();
                //}

                //if (ProcessoUsuario != null)
                //{

                //    logProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                //    logProcesso.Status = "PAUSA";
                //    logProcesso.DataInicio = ProcessoUsuario.DataMovimento;

                //    _bancoContext.LogProcessos.Entry(logProcesso).State = EntityState.Added;
                //    _bancoContext.LogProcessos.Add(logProcesso);
                //    _bancoContext.SaveChanges();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public async Task AddLogProcessoFim(ProcessoUsuario ProcessoUsuario)
        {
            try
            {
                LogProcesso LogProcesso = new();
                TimeSpan? diferencaTempo;

                var LogProcessoPausado = await _bancoContext.LogProcessos
                    .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                    .Where(d => d.DataFim == null)
                    .Where(e => e.Status.Equals("PAUSA"))
                    .OrderByDescending(o => o.Id)
                    .FirstOrDefaultAsync();

                var LogProcessoIniciado = await _bancoContext.LogProcessos
                    .Where(x => x.IdProcessoUsuario == ProcessoUsuario.Id)
                    .Where(d => d.Status.Equals("INICIO"))
                    .Where(e => e.DataFim == null)
                    .OrderByDescending(o => o.Id)
                    .FirstOrDefaultAsync();

                if (LogProcessoPausado != null && ProcessoUsuario != null)
                {
                    LogProcessoPausado.DataFim = ProcessoUsuario.DataFinal;
                    diferencaTempo = LogProcessoPausado.DataFim - LogProcessoPausado.DataInicio;
                    LogProcessoPausado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;
                    _bancoContext.LogProcessos.Entry(LogProcessoPausado).State = EntityState.Modified;
                    await _bancoContext.SaveChangesAsync();
                }

                if (LogProcessoIniciado != null && ProcessoUsuario != null)
                {
                    LogProcessoIniciado.DataFim = ProcessoUsuario.DataMovimento;
                    diferencaTempo = LogProcessoIniciado.DataFim - LogProcessoIniciado.DataInicio;
                    LogProcessoIniciado.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;
                    _bancoContext.LogProcessos.Entry(LogProcessoIniciado).State = EntityState.Modified;
                    await _bancoContext.SaveChangesAsync();
                }

                if (ProcessoUsuario != null)
                {
                    LogProcesso.IdProcessoUsuario = ProcessoUsuario.Id;
                    LogProcesso.DataInicio = ProcessoUsuario.DataFinal;
                    LogProcesso.DataFim = ProcessoUsuario.DataFinal;
                    LogProcesso.Status = "FIM";
                    diferencaTempo = LogProcesso.DataFim - LogProcesso.DataInicio;
                    LogProcesso.TempoDecorrido = (long?)diferencaTempo.Value.TotalSeconds;

                    _bancoContext.LogProcessos.Entry(LogProcesso).State = EntityState.Added;
                    await _bancoContext.LogProcessos.AddAsync(LogProcesso);
                    await _bancoContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public async Task UpdateLogProcesso(LogProcesso LogProcesso)
        {
            //var log = this.GetLogProcessoByUser(LogProcesso.IdUsuario).Result.Where(c=> c.DataInicio != null).Where(d=> d.DataFim == null).FirstOrDefault();
            //try
            //{
            //    if (log != null)
            //    {
            //        log.DataFim = DateTime.Now;
            //        _bancoContext.LogProcessos.Entry(log).State = EntityState.Modified;
            //        _bancoContext.SaveChanges();
            //    }
            //}catch(Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                _bancoContext.LogProcessos.Entry(LogProcesso).State = EntityState.Modified;
                await _bancoContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LogProcesso> GetLastLogProcessoByIdProcesso(int idProcessoUsuario)
        {
            try
            {
                var logProcesso = await _bancoContext.LogProcessos
                      .Where(x => x.IdProcessoUsuario == idProcessoUsuario)
                      .Where(d => d.Status.Equals("FIM")).FirstAsync();
                return logProcesso;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
