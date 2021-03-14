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

CREATE OR REPLACE FUNCTION usersIzpis1()
RETURNS table(email varchar) AS
$$
    DECLARE

    BEGIN
        RETURN QUERY
        SELECT u.email
        FROM users u;
		
    END;
$$ LANGUAGE 'plpgsql';

CCREATE OR REPLACE FUNCTION usersIzpisOboje1(ime varchar)
RETURNS varchar AS
$$
DECLARE
pass varchar;
BEGIN

SELECT u.password INTO pass
FROM users u
WHERE u.email = ime;
RETURN pass;
END;
$$ LANGUAGE 'plpgsql';

//vrni postno stevilko

CREATE OR REPLACE FUNCTION vrniPostnoSt (krajj varchar) 
RETURNS varchar 
AS $$ 
DECLARE 
postnaa varchar;
BEGIN

SELECT k.postna_stevilka INTO postnaa
FROM kraji k
WHERE k.ime_kraja = krajj;

return postnaa;


END; $$ 
LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION dodajAdmin(ime varchar)
RETURNS void AS
$$
DECLARE

BEGIN
UPDATE users
SET admin = true
WHERE email = ime;
END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION izbrisiUserja(ime varchar)
RETURNS void AS
$$
DECLARE

BEGIN
DELETE FROM users u
WHERE u.email = ime;

END;
$$ LANGUAGE 'plpgsql';


CREATE OR REPLACE FUNCTION updateUser(imes varchar, geslos varchar,imen varchar, geslon varchar)
RETURNS void AS
$$
DECLARE

BEGIN
UPDATE users u
SET u.email = imen AND u.password = geslon
WHERE u.email = imes AND u.password = geslosM;

END;
$$ LANGUAGE 'plpgsql';


CREATE OR REPLACE FUNCTION updateUser(imes varchar, geslos varchar,imen varchar, geslon varchar)
RETURNS void AS
$$
DECLARE

BEGIN
UPDATE users 
SET email = imen, password = geslon
WHERE email = imes AND password = geslos;

END;
$$ LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION admin(ime varchar)
RETURNS bool AS
$$
DECLARE
adminn bool;
BEGIN
SELECT admin INTO adminn FROM users u
WHERE email = ime;
RETURN adminn;
END;
$$ LANGUAGE 'plpgsql';

//za izpis gmaila
CREATE OR REPLACE FUNCTION gmailUserja(imee varchar,priimekk varchar) 
RETURNS varchar 
AS $$ 
DECLARE 
gmail varchar; 
BEGIN

SELECT z.email INTO gmail 
FROM zaposleni z 
WHERE z.ime = imee AND z.priimek = priimekk;


RETURN gmail; 

END; $$ 
LANGUAGE 'plpgsql';

// izpis kraja
CREATE OR REPLACE FUNCTION krajIzpis (imee varchar,priimekk varchar) 
RETURNS varchar 
AS $$ 
DECLARE 
krajime varchar; 
BEGIN

SELECT k.ime_kraja INTO krajime 
FROM zaposleni z INNER JOIN kraji k ON z.kraj_id = k.id
WHERE z.ime = imee AND z.priimek = priimekk;


RETURN krajime; 

END; $$ 
LANGUAGE 'plpgsql';

//izbriss uporabnika

SELECT CREATE OR REPLACE FUNCTION IzbrisUporabnika (imee varchar,priimekk varchar) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

DELETE FROM zaposleni z
WHERE z.ime = imee AND z.priimek = priimekk;




END; $$ 
LANGUAGE 'plpgsql';


CREATE FUNCTION arhiviraj()
    RETURNS trigger
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE NOT LEAKPROOF
AS $BODY$
BEGIN

        INSERT INTO arhivi(id, password, email, admin)
        VALUES(NEW.id, NEW.password, NEW.email, NEW.admin);

    RETURN NULL;
    END;
$BODY$;

CREATE OR REPLACE FUNCTION oddelki()
RETURNS table(ime_oddelka varchar) AS
$$
    DECLARE

    BEGIN
        RETURN QUERY
        SELECT o.ime_oddelka
        FROM oddelki o;
		
    END;
$$ LANGUAGE 'plpgsql';


CREATE OR REPLACE FUNCTION oddelkiDodaj(imee varchar)
RETURNS void AS
$$
    DECLARE

    BEGIN
      INSERT INTO oddelki(ime_oddelka) VALUES(imee);
	  
		
    END;
$$ LANGUAGE 'plpgsql';

//update uporabnika
CREATE OR REPLACE FUNCTION updateUporabnika (krajj varchar, imee varchar,priimekk varchar, emaill varchar, starime varchar, starpriimek varchar) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

UPDATE zaposleni 
SET ime = imee , priimek = priimekk , email = emaill , kraj_id = (SELECT id FROM kraji k WHERE k.ime_kraja = krajj)
WHERE ime = starime AND priimek = starpriimek;




END; $$ 
LANGUAGE 'plpgsql';

// delete kraji

CREATE OR REPLACE FUNCTION DeleteKraji (krajj varchar, postnaa integer) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

DELETE FROM kraji
WHERE ime_kraja = krajj AND postna_stevilka = postnaa;




END; $$ 
LANGUAGE 'plpgsql';

//update kraji 

CREATE OR REPLACE FUNCTION UpdateKraji (krajj varchar, postnaa integer, starkraj varchar, startaPostna integer) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

UPDATE kraji 
SET ime_kraja = krajj , postna_stevilka = postnaa
WHERE ime_kraja = starkraj AND postna_stevilka = startaPostna;




END; $$ 
LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION DodajZkraju(imee varchar, priimekk varchar, datum_rojj timestamp, emaill varchar,imek varchar, postna integer)
RETURNS void AS
$$
DECLARE

BEGIN
INSERT INTO kraji(ime_kraja,postna_stevilka) VALUES(imek, postna);

INSERT INTO zaposleni(ime, priimek, datum_roj, email, kraj_id)
VALUES(imee,priimekk,datum_rojj,emaill,(SELECT id FROM kraji WHERE ime_kraja = imek));

END;
$$ LANGUAGE 'plpgsql';

//delete kraji

CREATE OR REPLACE FUNCTION InsertKraji (krajj varchar, postnaa integer) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

UPDATE zaposleni SET
kraj_id = (SELECT id FROM kraji WHERE ime_kraja = 'BREZ')
WHERE kraj_id = (SELECT id FROM kraji WHERE ime_kraja = krajj AND postna_stevilka = postnaa);


DELETE FROM kraji
WHERE ime_kraja = krajj AND postna_stevilka = postnaa;




END; $$ 
LANGUAGE 'plpgsql';

//insert into kraji

CREATE OR REPLACE FUNCTION InsertKraji (krajj varchar, postnaa integer) 
RETURNS void 
AS $$ 
DECLARE 

BEGIN

INSERT INTO kraji(ime_kraja,postna_stevilka) VALUES(krajj,postnaa);



END; $$ 
LANGUAGE 'plpgsql';





//trigger

CREATE TRIGGER arhiviraj
    AFTER INSERT
    ON users
    FOR EACH ROW
    EXECUTE PROCEDURE arhiviraj();
    
    
    
    

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
