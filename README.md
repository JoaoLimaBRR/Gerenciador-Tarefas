public static string ObterTipoPessoa(string documento)
{
    if (string.IsNullOrWhiteSpace(documento) || documento.Length != 14)
        throw new ArgumentException("Documento inválido.");

    string doc11 = documento.Substring(documento.Length - 11); // Para validar como CPF
    string doc14 = documento; // Para validar como CNPJ

    if (ValidarCpf(doc11))
        return "PF";

    if (ValidarCnpj(doc14))
        return "PJ";

    throw new ArgumentException("Documento inválido como CPF ou CNPJ.");
}

public static bool ValidarCpf(string cpf)
{
    if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
        return false;

    var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
    var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

    string tempCpf = cpf.Substring(0, 9);
    int soma = 0;

    for (int i = 0; i < 9; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

    int resto = soma % 11;
    resto = resto < 2 ? 0 : 11 - resto;
    string digito = resto.ToString();

    tempCpf += digito;
    soma = 0;

    for (int i = 0; i < 10; i++)
        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

    resto = soma % 11;
    resto = resto < 2 ? 0 : 11 - resto;
    digito += resto.ToString();

    return cpf.EndsWith(digito);
}



public static bool ValidarCnpj(string cnpj)
{
    if (cnpj.Length != 14 || cnpj.Distinct().Count() == 1)
        return false;

    int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
    int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

    string tempCnpj = cnpj.Substring(0, 12);
    int soma = 0;

    for (int i = 0; i < 12; i++)
        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

    int resto = soma % 11;
    resto = resto < 2 ? 0 : 11 - resto;
    string digito = resto.ToString();

    tempCnpj += digito;
    soma = 0;

    for (int i = 0; i < 13; i++)
        soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

    resto = soma % 11;
    resto = resto < 2 ? 0 : 11 - resto;
    digito += resto.ToString();

    return cnpj.EndsWith(digito);
}

