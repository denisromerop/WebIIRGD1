using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebCampeonato.Models;

namespace WebCampeonato
{
    public partial class CampeonatoContext : DbContext
    {
        public CampeonatoContext()
        {
        }

        public CampeonatoContext(DbContextOptions<CampeonatoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arbitro> Arbitro { get; set; }
        public virtual DbSet<Cartao> Cartao { get; set; }
        public virtual DbSet<Jogador> Jogador { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<JogoArbitro> JogoArbitro { get; set; }
        public virtual DbSet<JogoJogadorCartao> JogoJogadorCartao { get; set; }
        public virtual DbSet<Time> Time { get; set; }
        public virtual DbSet<TimeJogo> TimeJogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Campeonato;Trusted_connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arbitro>(entity =>
            {
                entity.HasIndex(e => e.Federacao)
                    .HasName("UK_Arbitro_Federacao")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UK_Arbitro_Nome")
                    .IsUnique();

                entity.Property(e => e.Federacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fifa).HasColumnName("FIFA");

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Posicao)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cartao>(entity =>
            {
                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jogador>(entity =>
            {
                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.IdTime).HasColumnName("Id_Time");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Posicao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTimeNavigation)
                    .WithMany(p => p.Jogador)
                    .HasForeignKey(d => d.IdTime)
                    .HasConstraintName("FK_Jogador_Time");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.Property(e => e.DataHora)
                    .HasColumnName("Data_Hora")
                    .HasColumnType("datetime");

                entity.Property(e => e.Local)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JogoArbitro>(entity =>
            {
                entity.ToTable("Jogo_Arbitro");

                entity.Property(e => e.IdArbitro).HasColumnName("Id_Arbitro");

                entity.Property(e => e.IdJogo).HasColumnName("Id_Jogo");

                entity.HasOne(d => d.IdArbitroNavigation)
                    .WithMany(p => p.JogoArbitro)
                    .HasForeignKey(d => d.IdArbitro)
                    .HasConstraintName("FK_Jogo_Arbitro_Arbitro");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.JogoArbitro)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK_Jogo_Arbitro_Jogo");
            });

            modelBuilder.Entity<JogoJogadorCartao>(entity =>
            {
                entity.ToTable("Jogo_Jogador_Cartao");

                entity.Property(e => e.IdCartao).HasColumnName("Id_Cartao");

                entity.Property(e => e.IdJogador).HasColumnName("Id_Jogador");

                entity.Property(e => e.IdJogo).HasColumnName("Id_Jogo");

                entity.HasOne(d => d.IdCartaoNavigation)
                    .WithMany(p => p.JogoJogadorCartao)
                    .HasForeignKey(d => d.IdCartao)
                    .HasConstraintName("FK_Jogo_Jogador_Cartao_Cartao");

                entity.HasOne(d => d.IdJogadorNavigation)
                    .WithMany(p => p.JogoJogadorCartao)
                    .HasForeignKey(d => d.IdJogador)
                    .HasConstraintName("FK_Jogo_Jogador_Cartao_Jogador");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.JogoJogadorCartao)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK_Jogo_Jogador_Cartao_Jogo");
            });

/*            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.Property(e => e.nome)
                    .HasMaxLength(100)
                    .IsUnicode(true);
            });
*/

            modelBuilder.Entity<Time>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("UK_Time_Nome")
                    .IsUnique();

                entity.Property(e => e.EscudoCaminho)
                    .HasColumnName("Escudo_Caminho")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.FotoOficialCaminho)
                    .HasColumnName("Foto_Oficial_Caminho")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Gc).HasColumnName("GC");

                entity.Property(e => e.Gp).HasColumnName("GP");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeJogo>(entity =>
            {
                entity.ToTable("Time_Jogo");

                entity.Property(e => e.IdJogo).HasColumnName("Id_Jogo");

                entity.Property(e => e.IdTime).HasColumnName("Id_Time");

                entity.HasOne(d => d.IdJogoNavigation)
                    .WithMany(p => p.TimeJogo)
                    .HasForeignKey(d => d.IdJogo)
                    .HasConstraintName("FK_Time_Jogo_Jogo");

                entity.HasOne(d => d.IdTimeNavigation)
                    .WithMany(p => p.TimeJogo)
                    .HasForeignKey(d => d.IdTime)
                    .HasConstraintName("FK_Time_Jogo_Time");
            });

        }
    }
}
