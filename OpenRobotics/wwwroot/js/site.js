// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//MÁSCARA PARA CELULAR
window.addEventListener('DOMContentLoaded', function () {
    var telefoneInput = document.getElementById('celular');

    telefoneInput.addEventListener('input', function () {
        var telefone = telefoneInput.value;

        // Remove todos os caracteres que não sejam números
        telefone = telefone.replace(/\D/g, '');

        // Bloqueia a entrada de letras
        telefoneInput.value = telefoneInput.value.replace(/[^0-9]/g, '');

        // Aplica a máscara do telefone com DDD
        if (telefone.length === 11) {
            telefone = telefone.replace(/(\d{2})(\d{5})(\d{4})/, '($1) $2-$3');
        } else if (telefone.length === 10) {
            telefone = telefone.replace(/(\d{2})(\d{4})(\d{4})/, '($1) $2-$3');
        }

        telefoneInput.value = telefone;
    });
});

//MÁSCARA PARA CNPJ E CPF
function formatInput() {
    const inputField = document.getElementById('cnpjcpf');
    let currentValue = inputField.value.replace(/\D/g, '');

    if (currentValue.length <= 11) {
        // CPF: Aplicar a máscara (###.###.###-##)
        currentValue = currentValue.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
    } else {
        // CNPJ: Aplicar a máscara (##.###.###/####-##)
        inputField.maxLength = 18;
        currentValue = currentValue.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
    }

    inputField.value = currentValue;
}

//MÁSCARA PARA CEP
function mascaraCEP(cep) {
    cep = cep.replace(/\D/g, ''); // Remove caracteres não numéricos

    if (cep.length <= 5) {
        return cep;
    }

    // Insere o hífen na máscara
    cep = cep.replace(/^(\d{5})(\d)/, '$1-$2');

    return cep;
}

function formatarCEP() {
    var inputCEP = document.getElementById('cep');
    var cep = inputCEP.value;
    var cepFormatado = mascaraCEP(cep);
    inputCEP.value = cepFormatado;
}



//CAMPO DE PESQUISA PARA TABELAS
window.addEventListener('DOMContentLoaded', function () {
    var campoPesquisa = document.getElementById('pesquisa');

    campoPesquisa.addEventListener('input', function () {
        var termoPesquisa = campoPesquisa.value.toLowerCase();

        var tabela = document.getElementById('tabela');
        var linhas = tabela.getElementsByTagName('tr');

        for (var i = 1; i < linhas.length; i++) {
            var colunas = linhas[i].getElementsByTagName('td');
            var encontrado = false;

            for (var j = 0; j < colunas.length; j++) {
                var conteudo = colunas[j].innerHTML.toLowerCase();

                if (conteudo.indexOf(termoPesquisa) > -1) {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado) {
                linhas[i].style.display = '';
            } else {
                linhas[i].style.display = 'none';
            }
        }
    });
});