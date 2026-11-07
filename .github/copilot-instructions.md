# GitHub Copilot Instructions for More Thrumbos (Continued) Mod

## Mod Overview and Purpose

**Mod Name:** More Thrumbos (Continued)  
**Author:** Cenbes  
**Version:** 1.4.5  
**Mod Description:**  
This is a RimWorld mod that adds four new Thrumbo types (Ginger, Blond, Silver, and Black) with unique characteristics and products. Each type has improved stats, special hediffs for war mounts, faster fur growth for shearing, and milk production for cheese. Additionally, it includes a Bionic Thrumbo with corrupted data.

## Key Features and Systems

- **New Thrumbo Types:**
  - **Ginger Thrumbo:** Bigger, stronger, faster, and more resistant. Used as a war mount.
  - **Blond Thrumbo:** Smaller, faster, and more resistant. Also used as a war mount.
  - **Silver Thrumbo:** Normal size, more resistant and faster. Suitable for courier animals.
  - **Black Thrumbo:** Enormous size, real powerhourse with decent speed and defense.
  - **Bionic Thrumbo:** Data entry corrupted, needs further development.

- **Products:**
  - Faster fur growth for shearing.
  - High-nutrient milk production from females.
  - Recipes for cheese, chocolate, and other dairy products.

- **Compatibility:**
  - Requires specific load order to ensure maximum compatibility.
  - Compatible with various other mods like Giddy-Up!, Animal Gear Basic, VGP Garden Gourmet, and more.

## Coding Patterns and Conventions

- **C# Coding:**
  - Follow RimWorld's coding conventions and patterns.
  - Use meaningful variable and method names.
  - Implement modding best practices for maintainability and compatibility.

- **XML Integration:**
  - Use XML definitions to define new Thrumbo types, recipes, and other mod elements.
  - Ensure XML files are properly structured and validated.

- **Harmony Patching:**
  - Use Harmony to patch existing RimWorld methods to add new functionality or modify existing behavior.
  - Write clean and efficient patches that do not interfere with other mods.

## XML Integration

- **Def Files:**
  - Create and modify XML definition files in the `Defs` directory.
  - Define new Thrumbo types, recipes, and other mod elements using appropriate tags and attributes.

- **Example XML Structure:**
  xml
  <Defs>
    <PawnKindDef>
      <defName>GingerThrumbo</defName>
      <label>Ginger Thrumbo</label>
      <description>A larger, stronger, and faster Thrumbo with special war mount capabilities.</description>
      <!-- Other XML tags and attributes -->
    </PawnKindDef>
  </Defs>
  

## Harmony Patching

- **Patch Structure:**
  - Create a Harmony patch in C# to modify existing RimWorld methods.
  - Use the `[HarmonyPatch]` attribute to specify the target method.
  - Implement the `Prefix`, `Postfix`, or `Transpiler` methods to add or modify functionality.

- **Example Harmony Patch:**
  csharp
  [HarmonyPatch(typeof(Thrumbo), "DoSomething")]
  public static class Patch_Thrumbo_DoSomething
  {
      [HarmonyPrefix]
      public static bool Prefix(Thrumbo __instance)
      {
          // Add custom logic before the original method executes
          return true; // Return true to allow the original method to execute
      }

      [HarmonyPostfix]
      public static void Postfix(Thrumbo __instance)
      {
          // Add custom logic after the original method executes
      }
  }
  

## Suggestions for Copilot

1. **Provide XML Definitions:**
   - When generating XML files, ensure that they include all necessary tags and attributes for defining new Thrumbo types and other mod elements.

2. **Implement Harmony Patches:**
   - When suggesting code for Harmony patches, ensure that they are clean and efficient, and do not interfere with other mods.

3. **Follow Coding Conventions:**
   - When generating C# code, follow RimWorld's coding conventions and best practices for maintainability and compatibility.

4. **Document Code and Patches:**
   - Include comments and documentation in the generated code and patches to explain their purpose and functionality.

5. **Test and Validate:**
   - After generating code and XML files, ensure that they are tested and validated in a RimWorld environment to ensure they work as intended.

By following these guidelines, you can create a high-quality and maintainable mod for RimWorld using GitHub Copilot. Happy coding!

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

