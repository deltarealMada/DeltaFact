
select fbvr.numbvrcomplet, concat_ws(' ',mid(numbvrcomplet, 0, 2), mid(numbvrcomplet, 2, 5), mid(numbvrcomplet, 7, 5), mid(numbvrcomplet, 12, 5), mid(numbvrcomplet, 17, 5), mid(numbvrcomplet, 22)) as numbvrspace, fact.reffacturedeltareal as fact_nofacture, fact.reffactureentreprise as fact_reffactureentreprise, date_format(fact.dateimpression, '%d.%m.%Y') as fact_datefacture, date_format(DATE_ADD(fact.dateimpression,INTERVAL entreprise.echeance day), '%d.%m.%Y') as fact_dateecheance, date_format(fact.datecommande, '%d.%m.%Y') as fact_datecommande, date_format(fact.datefacturedeltareal, '%d.%m.%Y') as fact_datefacturedeltareal, '' as fact_datepaiement, fact.totmontantbrut as fact_totalmontantbrut, concat(fact.tauxtva, '%') as fact_tvapourcent, fact.totrabais as fact_totalrabais, fact.tottva as fact_totaltvachf, fact.fraisenvoi as fact_fraisenvoi, fact.fraisassurance as fact_fraisassurance, fact.interets as fact_interets, fact.fraisrappel as fact_fraisrappel, (fact.totmontantbrut - fact.totrabais + fact.tottva) as fact_montantapayer, 0 as fact_montantpaye,


fact.numligne, article.codearticle as art_codearticle, concat_ws(char(13), if(trim(article.descriptif_ligne1) = '', null, article.descriptif_ligne1), if(trim(article.descriptif_ligne2) = '', null, article.descriptif_ligne2), if(trim(article.descriptif_ligne3) = '', null, article.descriptif_ligne3), if(trim(article.descriptif_ligne4) = '', null, article.descriptif_ligne4), if(trim(fact.remarquearticle) = '', null, fact.remarquearticle)) as art_libellearticle, fact.remarquearticle as art_remarque, unite.unitelibelle as art_unite, prix.prix as art_prixunitaire, fact.nbr as art_nbrarticle, (prix.prix * fact.nbr) as art_montantbrut, if(rabais.rabaispourcent>0, concat(rabais.rabaispourcent, '%'), '-') as art_rabaispourcent, if(if(isnull(rabais.rabaispourcent), 0, rabais.rabaispourcent) > 0, (fact.nbr* prix.prix) * rabais.rabaispourcent/100, if(isnull(rabais.rabaismontant), 0, rabais.rabaismontant)) as art_rabaischf, 



entreprise.identreprise, entreprise.iddeltareal, langent.letter, if(entreprise.iddeltareal > 0, clidel.socligne1, entreprise.socligne1) as ent_societe, if(entreprise.iddeltareal > 0, clidel.socligne2, entreprise.socligne2) as ent_societecompl, polent.politesselettre as ent_politesse, if(entreprise.iddeltareal > 0, foncdel.nomprenom, fonccli.nomprenom) as ent_nomprenom,  
if(entreprise.iddeltareal > 0, foncdel.adresse1, fonccli.adresse1) as ent_adresse1, if(entreprise.iddeltareal > 0, foncdel.adresse2, fonccli.adresse2) as ent_adresse2, 
if(entreprise.iddeltareal > 0, foncdel.co, fonccli.co) as ent_co, clicity.zip as ent_npa, clicity.cityname as ent_ville, if(entreprise.iddeltareal > 0, foncdel.comptebanque, fonccli.comptebanque) as ent_iban, concat(banque.nombanque, ' - ', banque.adresse, ', ', banque.npa, ' ', banque.ville) as ent_banqueccp, 
if(entreprise.iddeltareal > 0, clidel.numrc, entreprise.numtva) as ent_notva, entreprise.echeance as ent_echeancejour, if(entreprise.iddeltareal > 0, foncdel.email, fonccli.email) as ent_email, if(entreprise.iddeltareal > 0, foncdel.adresseweb, fonccli.siteweb) as ent_siteweb, 


client.idclient as iCli, concat_ws(char(13), if(trim(socligne) = '', null, socligne), concat(clientpolitesse.politesselettre, ' ', if(trim(client.nom) = '', null, client.nom), ' ', if(trim(client.prenom) = '', null, client.prenom)), if(trim(client.co) = '', null, client.co), concat_ws(' ', if(trim(client.adresse1) = '', null, client.adresse1), if(trim(client.adresse2) = '', null, client.adresse2)), concat(city.zip, ' ', city.cityname)) as cli_adressecomplet, 
client.socligne as cli_societe, clientpolitesse.politesselettre as cli_politesse, client.nom as cli_nom, client.prenom as cli_prenom, client.co as cli_co, client.adresse1 as cli_adresse1, client.adresse2 as cli_adresse2, city.zip as cli_npa, city.cityname as cli_ville, 



if (fact.nbrmens > 0, 'oui', 'non') as modemens, fact.nbrmens, 

 
 article.idarticle, 
article.codearticle, concat_ws('\n', article.descriptif_ligne1, if(article.remarque='', null, article.remarque)) as libellearticle, client.idclient, fact.identreprise, fact.idfacture, prix.idprix, rabais.idrabais 
from 
fact_facturation fact inner join (select idfacture, concat('000000', LPAD(identreprise,4,'0'), LPAD(reffacturedeltareal,10,'0'), date_format(now(), '%y%m%d'), ccpmodulo(concat('000000', LPAD(identreprise,4,'0'), LPAD(reffacturedeltareal,10,'0'), date_format(now(), '%y%m%d')))) as numbvrcomplet FROM fact_facturation) fbvr ON fbvr.idfacture = fact.idfacture

INNER join fact_entreprise entreprise on entreprise.identreprise = fact.identreprise
left join dta.client clidel on clidel.idclient = entreprise.iddeltareal
LEFT JOIN fact_entreprisefonction fonccli ON fonccli.identreprise = entreprise.identreprise AND (fonccli.idfonction = 1)
LEFT JOIN dta.clientfonction foncdel ON foncdel.idclient = entreprise.iddeltareal AND (foncdel.idfonctiondelta = 1)
LEFT join dta.typepolitesse polent ON polent.idpolitesse = if (entreprise.iddeltareal > 0, foncdel.idpolitesse, fonccli.idpolitesse) 
LEFT join dta.language langent ON langent.idlanguage = polent.idlangue 
left join dta.city clicity ON clicity.idcity = if (entreprise.iddeltareal > 0, foncdel.idville, fonccli.idville) 
LEFT JOIn dta.cpta_banque banque ON banque.idbanque = if (entreprise.iddeltareal > 0, foncdel.idbanque, fonccli.idbanque)


LEFT JOIN fact_client client ON client.idclient = fact.idclient left join   dta.city ON city.idcity = client.idville left join dta.typepolitesse clientpolitesse ON client.idpolitesse = clientpolitesse.idpolitesse

LEFT join fact_articles article ON article.idarticle = fact.idarticle left join (select idprix, idarticleprix, prix, dateprix from fact_prix group by idarticleprix, idprix order by dateprix desc) prix on prix.idarticleprix = article.idarticle and prix.idprix = fact.idprix 
LEFT JOIN (Select idrabais, idarticlerabais, rabaismontant, rabaispourcent, daterabaisde, daterabaisa FROM fact_rabais group by idarticlerabais, idrabais order by daterabaisa desc) rabais ON rabais.idarticlerabais = article.idarticle AND fact.idrabais = rabais.idrabais 
LEFT JOIN fact_unite unite ON unite.idunite = article.idunite 
where fact.reffacturedeltareal = '2017010003'
order by fact.reffacturedeltareal, fact.idclient, fact.numligne