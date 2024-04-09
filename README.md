Feito --Testar código para customizar lógica de salvar, ler e atualizar informações no banco de dados.

Testar usar alguma API do google qualquer para treinar.

Testar criar um container do docker para rodar o projeto em nuvem

***Cria Trigger e Function no Banco de dados Postgress

CREATE OR REPLACE FUNCTION stop_change_on_created_at()
  RETURNS trigger AS
$$
BEGIN
  -- always reset the auxId to the value already stored
  NEW.created_at := OLD.created_at;
  RETURN NEW;
END;
$$
language plpgsql;


CREATE TRIGGER avoid_created_at_changes
  BEFORE UPDATE
  ON customer
  FOR EACH ROW
  EXECUTE PROCEDURE stop_change_on_created_at();