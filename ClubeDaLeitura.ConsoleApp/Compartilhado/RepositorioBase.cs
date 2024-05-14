using ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase
{
    protected List<T> registros = new List<T>();

    protected int contadorId = 1;

    public void Cadastrar(T novoRegistro)
    {
        novoRegistro.Id = contadorId++;

        RegistrarItem(novoRegistro);
    }

    public bool Editar(int id, T novaEntidade)
    {
        novaEntidade.Id = id;

        foreach (T entidade in registros)
        {
            if (entidade == null)
                continue;

            else if (entidade.Id == id)
            {
                entidade.AtualizarRegistro(novaEntidade);

                return true;
            }
        }

        return false;
    }

    public bool Excluir(int id)
    {
        foreach (var registro in registros)
        {
            if (registro.Id == id)
            {
                registros.Remove(registro);
                return true;
            }
        }

        return false;
    }

    public List<T> SelecionarTodos()
    {
        return registros;
    }

    public T SelecionarPorId(int id)
    {
        foreach (var registro in registros)
        {
            T e = registro;

            if (e == null)
                continue;

            else if (e.Id == id)
                return e;
        }

        return null;
    }

    public bool Existe(int id)
    {
        foreach (var registro in registros)
        {
            T e = registro;

            if (e == null)
                continue;

            else if (e.Id == id)
                return true;
        }

        return false;
    }

    protected void RegistrarItem(T novoRegistro)
    {
        registros.Add(novoRegistro);
    }


}


