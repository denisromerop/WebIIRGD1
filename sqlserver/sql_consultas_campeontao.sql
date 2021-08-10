
use Campeonato;

--Atualiza GP E GC
--Select id_jogo,  id_time, sum(gols) Gols from time_JOGO group by id_time;

delete from Resultado

--Select * From resultado

--Gols Pró e Gols Contra
insert into resultado (id_jogo, id_time , Golspro, golsContra,vitorias,derrotas,empates,saldodeGol,qtdjogos, PontosGanhos)
Select tj.id_jogo, tj.id_time, tj.gols as GolsPro, (select sum(tji.gols) from time_jogo tji where tj.Id_Time <> tji.Id_Time and tj.id_jogo = tji.id_jogo) as GolsContra, 0 as Vitorias, 0 as Derrotas, 0 as Empates, 0 SaldodeGols, 0 as Qtdjogos, 0 as PontosGanhos  from time_jogo tj 

--Vitorias
update Resultado set vitorias = 1 where golsPro > golsContra
-- Derrotas
update Resultado set derrotas = 1 where golsPro < golsContra
-- Empates
update Resultado set empates = 1 where golsPro = golsContra

-- Saldos de Gol
update Resultado set Saldodegol = Golspro - golsContra;

-- Qtd_jogos
update Resultado set qtdjogos = 1

-- Pontos Ganhos 
update Resultado set PontosGanhos = (Vitorias * 3) + Empates

-- Times
update Time set Vitorias = (select sum(re.vitorias) from Resultado re where re.id_time = time.id) 
update Time set Empates = (select sum(re.empates) from Resultado re where re.id_time = time.id) 
update Time set derrotas = (select sum(re.derrotas) from Resultado re where re.id_time = time.id) 
update Time set GP = (select sum(re.golsPro) from Resultado re where re.id_time = time.id) 
update Time set gc = (select sum(re.golsContra) from Resultado re where re.id_time = time.id) 



