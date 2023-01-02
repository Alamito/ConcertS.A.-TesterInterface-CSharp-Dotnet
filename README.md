# 🤖 Testes de Interface da Página de Busca da Google 🤖
[![NPM](https://img.shields.io/github/license/Alamito/ConcertS.A.-TesterInterface-CSharp-Dotnet)](https://github.com/Alamito/ConcertS.A.-TesterInterface-CSharp-Dotnet/blob/main/LICENSE)

# 📜 Sobre o projeto 📜

<p align="justify" > Projeto dedicado ao desafio prático proposto pela empresa Concert Technologies em seu processo seletivo, no qual tem como objetivo realizar testes automatizados da página de busca do Google para avaliar a usabilidade bem como fazer uma análise crítica de funcionamento da mesma.</p>

# 🎥 Apresentação do projeto 🎥

Foram realizados ao total sete testes, no qual serão apresentados a seguir:
<p align="justify">
<ol>
<li><b>Teste de busca por URL</b>: foi avaliado inserindo no campo de busca uma URL válida (status: ✅);</li>
<li><b>Teste de busca por cliques</b>: foi avaliado inserindo o nome de um site espécifico no campo de busca, após clicando em "buscar" e, em seguida, clicando no determinado site (status: ✅);</li>
<li><b>Teste de busca por URL inválida</b>: foi avaliado inserindo no campo de busca uma URL inválida (status: ✅);</li>
<li><b>Teste de busca por imagens</b>: foi avaliado inserindo a URL de uma imagem no campo de busca do Google Lens (status: ✅);</li>
<li><b>Teste de caminho (href) dos ícones</b>: foi avaliado clicando no ícone do Google Meet (status: ✅);</li>
<li><b>Teste de caminho (href) de informações da página</b>: foi avaliado clicando no link "sobre" da página (status: ✅);</li>
<li><b>Teste de alteração de tema</b>: foi avaliado mudando o tema da página de "claro" para "escuro" (status: ✅).</li>
</ol>
</p>
###  A seguir está representado visualmente os testes automatizados:

https://user-images.githubusercontent.com/102616676/210240432-305cb9e1-a05e-4277-bf78-c29cabb68efb.mp4

Também foi implementado uma maneira de realizar uma Screenshot da tela caso o teste venha a ser concluído com sucesso.

# 🧬 Tecnologias utilizadas 🧬

- dotNet (.NET);
- Selenium WebDriver;
- Navegador Chrome;
- Extensão Katalon para o Chrome.

<p align="justify">Para formar os testes foi utilizado a extensão Katalon para gravar os passos de cada um dos sete testes, após foi inspecionado a página do caminho final de cada teste para pegar o XPath único daquela página para assegurar no momento do teste se a automatização chegou no lugar esperado. Por exemplo: no caso do teste de alteração de tema foi utilizado o atributo "content" da segunda tag "meta" do "header" da página, visto que nele continha a informação de que o tema foi alterado de "origin" para "dark".</p>

# ⚙️ Avaliação da usabilidade da página de buscas da Google ⚙️

<p align="justify">A página de buscas da Google possui uma interface clara e objetiva entregando ao usuário uma experiência simples ao utilizar o mecanismo sem muitos rodeios ou complicações. O site também fornece métodos alternativos para inserção de palavras, como a pesquisa por um teclado virtual caso o usuário esteja com problemas no teclado físico, assim como a pesquisa por voz para usuários com problemas motores por exemplo. Além disso, a página é extremamente eficiente no que tange a velocidade na busca pelo determinado conteúdo, bem como nas sugestões de palavras durante a busca pelo conteúdo no qual é muito efetiva caso o usuário a use como principal mecanismo de busca, visto que a página é inteligente o suficente para entregar sugestões adequadas ao perfil do usuário. Outro aspecto interessante é a busca por imagens que é competente em buscar por similaridades na determinada imagem buscada. Por fim, a página ainda carrega simplicidade ao acesso de outras ferramentas da empresa como na seção de ícones que leva a outras sites, como Gmail, Meet e Drive. Durante os testes não foi encontrado nenhum "bug" ou algo nesse sentido, portanto não há pontos negativos a serem levantados, pois a página de buscas da Google cumpre com excelência a atividade proposta.</p>

# ✍️ Autor ✍️
Alamir Bobroski Filho 
- www.linkedin.com/in/alamirdev

<p align = "center"><em>"O poder não vem do conhecimento mantido, mas do conhecimento compartilhado"</em></p> <p align = "center">Bill Gates</p>
