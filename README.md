# Slot Machine - Documentação 
**Versão:** 1.0  
**Engine:** Unity 2022.3+

🎰 Baixe o executável [aqui](https://drive.google.com/file/d/14_su1BxXyrbxCz-kxC4S293w7Zi8bOgV/view?usp=sharing)

---

## 📋 Visão Geral  
Este projeto é um jogo de slot machine digital com funcionalidades básicas de cassino, desenvolvido em Unity.
Foram utilizadas os seguinte design patterns:
  - **Mode-View-Controller** para separação de responsabilidades em Views;
  - **Singleton** para gerenciamento de sistemas globais.

As artes foram geradas pela IA **DALL-E** para garantir consistência visual.  

---

## 🛠️ Arquiteturas e Padrões  
### **Singleton**  
- Usado para classes de gerenciamento centralizado:
  - `AudioManager`: Gerencia o fluxo de aúdio do jogo.    
  - `GameManager`: Controla o fluxo do jogo.
  - `SlotMachineManager`: Gerencia o fluxo de instâncias das slot machines.  
  - `UIManager`: Gerencia elementos da interface.
 - Usado para classes de sistemas centralizado:
  - `CreditSystem`: Sincroniza o crédito do jogador.  
  - `JackpotSystem`: Sincroniza o jackpot entre máquinas.
  - `LogSystem`: Sincroniza o log de cada máquina.  

### **MVC (Model-View-Controller)**  
- **Model**: Classes de dados como `SymbolAssetConfig` e `GameConfig`.  
- **View**: Elementos UI e animações (ex: `SlotMachineView`).  
- **Controller**: Lógica de negócio (ex: `SlotMachineViewController`).  

---

## 🎮 Funcionalidades Principais  
1. **Inserir Créditos**  
   - Adicione créditos via teclado (ex: tecla `Space`).  
2. **Spin dos Reels**  
   - Gire os rolos com o botão **Spin** (custo: 1 crédito).  
3. **Cashout**  
   - Converta créditos acumulados em "saldo" (botão **Stop**).  
4. **Adicionar Máquinas**  
   - Simule múltiplas slots conectadas ao mesmo jackpot (botão **+**).  
5. **Remover Máquinas**  
   - Desconecte máquinas do sistema (botão **-**).  

---

## 🚀 Como Executar  
1. Clone o repositório.  
2. Abra o projeto no **Unity 2022.3+**.  
3. Navegue até `Scenes/MainScene.unity`.  
4. Pressione **Play** no Editor.  

---

## 📝 Notas Adicionais  
- **Logs**: Registros de eventos são salvos dentro do arquivo `SlotMachine_logs.txt`.  
