# 🌕 Projeto A3: Explorador Lunar VR

Experiência interativa em Realidade Virtual (Mobile) desenvolvida na Unity para a disciplina de **Teoria da Computação** e **Computação Gráfica**.

O projeto simula uma caminhada lunar com física personalizada, onde o jogador deve coletar recursos e interagir com uma base espacial, aplicando conceitos práticos de autômatos finitos e estruturas de dados.

## 🎮 Sobre o Projeto
O objetivo é proporcionar uma imersão na superfície lunar utilizando o Google Cardboard. O jogador assume o papel de um astronauta que precisa coletar amostras de minérios para abastecer seu foguete e retornar à Terra.

### 🚀 Funcionalidades Principais
- **Gravidade Esférica:** Sistema de física customizado que permite caminhar ao redor de um planeta esférico (a Lua) sem cair no "vazio".
- **Realidade Virtual Mobile:** Integração com **Google Cardboard SDK** para renderização estereoscópica.
- **Gráficos Otimizados:** Uso do pipeline **URP (Universal Render Pipeline)** e shaders Unlit para performance em celulares.
- **Cinemáticas (Timeline):** Cutscenes de pouso e decolagem do foguete com transições de fade.

### 🧠 Aplicação de Teoria da Computação
O projeto integra conceitos teóricos na lógica do gameplay:
1.  **Autômato de Pilha (AP):** Implementado no sistema de inventário. Os minérios são "empilhados" (PUSH) na mochila e "desempilhados" (POP) ao serem entregues no foguete.
2.  **Autômato Finito Determinístico (AFD):** Controle das portas da base lunar (Estados: Trancada, Fechada, Aberta) e sistema de vida/oxigênio.
3.  **Autômato Finito Não-Determinístico (AFN):** Comportamento aleatório do OVNI que orbita o cenário, alternando entre estados de órbita e movimento livre.
4.  **Eventos de Região:** Gatilhos invisíveis que disparam eventos (como a passagem de um asteroide) baseados na posição do jogador.

## 🛠️ Tecnologias Utilizadas
- **Engine:** Unity 2022/2023 (URP)
- **Linguagem:** C#
- **Plugins:** Google Cardboard XR Plugin, Input System (New).
- **Controle:** Gamepad Bluetooth (Xbox/Genérico).

## 📱 Requisitos Mínimos
- **Android:** Versão 8.0 (Oreo) ou superior.
- **Hardware:** Celular com giroscópio.
- **Acessório:** Óculos VR compatível com Google Cardboard.
- **Controle:** Joystick Bluetooth conectado ao celular.

# 🕹️ Guia de Instalação e Uso

Como rodar a experiência no seu Android:

### 1. Preparação (Antes de abrir o App)
O jogo requer um controle físico, pois o toque na tela é bloqueado pelo óculos VR.
1.  Ligue o **Bluetooth** do seu celular.
2.  Conecte seu **Controle (Xbox, PlayStation ou Genérico)** ao celular.
3.  Coloque o celular no adaptador **Google Cardboard** (ou similar).

### 2. Instalação
1.  Baixe o arquivo `.APK` (disponível na aba [Releases]).
2.  Autorize a instalação de fontes desconhecidas se necessário.
3.  Abra o aplicativo.

### 3. Controles
O jogo utiliza um esquema de controle simples para evitar enjoo em VR:

| Ação | Botão (Xbox) | Botão (PlayStation) |
| :--- | :---: | :---: |
| **Mover** | Analógico Esquerdo | Analógico Esquerdo |
| **Olhar** | Giroscópio (Mova a cabeça) | Mova a cabeça |
| **Pular** | Botão A | Botão X |
| **Interagir** | Botão X | Botão Quadrado |

### 4. Objetivo
1.  Assista à cutscene de pouso.
2.  Explore a cratera e encontre **5 Minérios Lunares**.
3.  Retorne ao Foguete e entre na zona de carga para depositar os minérios.
4.  Aguarde a confirmação de "Missão Cumprida" para ver a decolagem final.
