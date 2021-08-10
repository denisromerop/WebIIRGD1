--DROP TRIGGEr tgr_time_jogo_iud;

CREATE TRIGGER tgr_time_jogo_iud
ON time_jogo
FOR INSERT,UPDATE,DELETE
AS
BEGIN
  execute sp_atualizaCampeonato
END
GO