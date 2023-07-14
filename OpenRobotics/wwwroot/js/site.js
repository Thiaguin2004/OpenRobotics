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

//MÁSCARA PARA CPF
window.addEventListener('DOMContentLoaded', function () {
    var cpfInput = document.getElementById('cpf');

    cpfInput.addEventListener('input', function () {
        var cpf = cpfInput.value;

        // Remove todos os caracteres que não sejam números
        cpf = cpf.replace(/\D/g, '');

        // Bloqueia a entrada de letras
        cpfInput.value = cpfInput.value.replace(/[^0-9]/g, '');

        // Aplica a máscara do CPF
        if (cpf.length > 3 && cpf.length <= 6) {
            cpf = cpf.replace(/(\d{3})(\d{1,3})/, '$1.$2');
        } else if (cpf.length > 6 && cpf.length <= 9) {
            cpf = cpf.replace(/(\d{3})(\d{3})(\d{1,3})/, '$1.$2.$3');
        } else if (cpf.length > 9 && cpf.length <= 11) {
            cpf = cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{1,2})/, '$1.$2.$3-$4');
        }

        cpfInput.value = cpf;
    });
});

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