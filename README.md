# projekt_music


CREATE OR REPLACE FUNCTION Dodaj2(imee varchar, priimekk varchar, datum_rojj timestamp, emaill varchar, krajj varchar)
RETURNS void AS
$$
DECLARE

BEGIN
INSERT INTO zaposleni(ime, priimek, datum_roj, email, kraj_id)
VALUES(imee,priimekk,datum_rojj,emaill,(SELECT id FROM kraji WHERE ime_kraja = krajj));

END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Izpis1()
RETURNS TABLE (ime varchar, priimek varchar, datum_roj timestamp, email varchar, ime_oddelka varchar, ime_kraja varchar) AS
$$
DECLARE

BEGIN
RETURN QUERY
SELECT z.ime, z.priimek, z.datum_roj,z.email,o.ime_oddelka,k.ime_kraja
FROM zaposleni z INNER JOIN oddelki o ON z.oddelek_id = o.id
INNER JOIN kraji k ON k.id = z.kraj_id;

END;
$$ LANGUAGE 'plpgsql';



//za vstavljanje userjov (registracija)
DECLARE
BEGIN
INSERT INTO users(email,password) VALUES(emaill,pass);
END;

CREATE OR REPLACE FUNCTION izpisZaposlenih1()
RETURNS table(ime varchar) AS
$$
    DECLARE

    BEGIN
        RETURN QUERY
        SELECT z.ime
        FROM zaposleni z;
    END;
$$ LANGUAGE 'plpgsql';


CREATE OR REPLACE FUNCTION izpisZaposlenihPriimek(imee varchar)
RETURNS table(priimek varchar) AS
$$
    DECLARE

    BEGIN
        RETURN QUERY
        SELECT z.priimek
        FROM zaposleni z
		WHERE imee = z.ime;
    END;
$$ LANGUAGE 'plpgsql';





/* se potrebno narediti
- gesla criptirati

- narediti do konca urejanje uporabnikov
- popraviti prikaz uporabnikov

- dodaja gumbov za premikanje po aplikciji
- narediti prikaz zaposlenih 
- narediti da admin lahko določi zaposlenim oddelek
- narediti prikaz zaposlenih za update in delete 

- pri krajih da dela combobox za urejanje in brisanje in da se vnasa v textboxe pridobljen text
- naredi dodaja krajev

- narediti 3 triggerje al 2 sj nevem vec
- //nevem ce bo mozno - narediti novo tabelo settings, da lahko uporabnik spreminja barvo ozadja in font texta
- Izdelaj vsaj en strežniški podprogram, kjer preko ene akcije (enega strežniškega podprograma) vnašaj v vsaj dve tabeli.
- Izdelaj eno log tabelo (kaj shranjuješ notri - katero arhivo, je tvoja izbira).
- Napolnjena baza! Toliko, da bom lahko preizkusil delovanje aplikacije.
- TO Izvoz poročila (neka statistika) v excel. ALI Prikaz grafa v aplikaciji.

- polepsaj "Pregled"
- polepsaj "Urejanje/Vstavljanje"
- polepsaj "Kraji"
- polepsaj "Uporabniki"
- oplepsaj(ko naredis dodajanje oddelkov z adminsko pravico) "Dodajanje Oddelkov"
