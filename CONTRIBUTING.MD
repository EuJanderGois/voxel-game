# 🤝 Contribuindo para o Voxel Game

Obrigado pelo interesse em contribuir com o **Voxel Game**! 🚀  
Esse projeto é focado em **aprendizado** e toda ajuda é bem-vinda.

Não há nehum preconceito relacionado ao uso de IA, desde que isso não afete a organização, funcionamento e manutenção.

---

## 📌 Como contribuir

1. **Faça um fork** do repositório  
2. Crie uma **branch** para sua feature/bugfix:  
   ```bash
   git checkout -b minha-feature
   ```
3. Faça suas alterações e **commite**:  
   ```bash
   git commit -m "Adiciona nova funcionalidade X"
   ```
4. Envie para seu fork:  
   ```bash
   git push origin minha-feature
   ```
5. Abra um **Pull Request** aqui no GitHub

---

## 🛠️ Padrões de código

- O projeto usa **Godot 4** com **C#**  
- Mantenha nomes de classes em **PascalCase** (`PlayerController`, `BlockFaces`)  
- Nomes de variáveis e métodos em **camelCase** (`moveSpeed`, `getBreakSpeed`)  
- Sempre que possível, documente suas classes e métodos com **XML Docs**

Exemplo:
```csharp
/// <summary>
/// Classe que representa um bloco básico no mundo.
/// </summary>
public class Block : Node3D
{
    ...
}
```

---

## 🧪 Testes e boas práticas

- Sempre teste suas alterações no Godot antes de abrir o PR  
- Evite "commits gigantes" → prefira **commits pequenos e descritivos**  
- Se possível, atualize também o **CHANGELOG.md** ao adicionar uma feature

---

## 📜 Código de Conduta

Este projeto adota um código de conduta simples:  
**seja respeitoso, colaborativo e paciente.** 💙

---

## 💡 Ideias de contribuição

- Melhorar movimentação do jogador  
- Implementar mineração e ferramentas  
- Criar sistema de inventário  
- Adicionar geração procedural de terreno  
- Otimizar a estrutura de blocos/chunks  

---

Muito obrigado por ajudar a construir o **Voxel Game** ✨  
