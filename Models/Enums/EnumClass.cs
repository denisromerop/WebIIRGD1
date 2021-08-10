using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCampeonato.Models.Enums
{

    public enum cartaoenum { amarelo, vermelho }

    public enum  saleStatus : int
    {
        Pending = 0,
        Billed = 1,
        Canceled = 2
    }

    public enum FederaEnum : int
    {
        AC_Acre = 0 ,AL_Alagoas = 1
    }
    public enum FederacaoEnum 
    {
        AC_Acre, AL_Alagoas, AP_Amapá, AM_Amazonas, BA_Bahia, CE_Ceará, DF_DistritoFederal, ES_EspíritoSanto, GO_Goiás, MA_Maranhão, MT_MatoGrosso, MS_Mato_Grosso_do_Sul, MG_Minas_Gerais, PA_Pará, PB_Paraíba, PR_Paraná, PE_Pernambuco, PI_Piauí, RJ_Rio_de_Janeiro, RN_Rio_Grande_do_Norte, RS_Rio_Grande_do_Sul, RO_Rondônia, RR_Roraima, SC_Santa_Catarina, SP_São_Paulo, SE_Sergipe, TO_Tocantins 
    }

    public enum posicaoarbitroenum  
      { Arbitro, Auxiliar }
} 


