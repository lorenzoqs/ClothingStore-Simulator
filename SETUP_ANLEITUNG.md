# SETUP ANLEITUNG - Clothing Store Simulator

## Schritt 1: Projekt in Unity erstellen

```bash
# Repository klonen
git clone https://github.com/lorenzoqs/ClothingStore-Simulator.git
cd ClothingStore-Simulator
```

## Schritt 2: Unity Scene aufbauen

### Szene-Hierarchie:
```
MainGame (Scene)
├── Player
│   ├── MainCamera
│   └── Rigidbody (Dynamic)
├── Store
│   ├── Floor (Plane)
│   ├── Walls (Cubes)
│   ├── Shelf_1 (mit ClothingItems)
│   ├── Shelf_2 (mit ClothingItems)
│   ├── Shelf_3 (mit ClothingItems)
│   ├── Register (Counter)
│   └── Door_To_Backroom
├── Backroom
│   ├── Floor
│   ├── Walls
│   ├── Plant_1
│   ├── Plant_2
│   ├── Plant_3
│   └── Door_To_Store
├── Canvas (UI)
│   ├── MoneyText
│   ├── DayText
│   ├── TimeText
│   ├── DeliveryText
│   └── NotificationText
├── Managers
│   ├── GameManager (GameObject)
│   ├── UIManager (GameObject)
│   ├── DeliveryManager (GameObject)
│   └── CustomerSpawner (GameObject)
└── Lighting
    └── DirectionalLight
```

## Schritt 3: Player Setup

### GameObject "Player" erstellen:
1. Rechtsklick → 3D Object → Capsule → benenne es "Player"
2. Position: (0, 1, 0)
3. Scale: (1, 1, 1)

### Komponenten hinzufügen:
- **Rigidbody**:
  - Mass: 1
  - Drag: 5
  - Angular Drag: 0.05
  - Freeze Rotation: X, Y, Z (alle fixieren)
  - Collision Detection: Continuous

- **Collider**:
  - Capsule Collider (Standard)
  - Radius: 0.5
  - Height: 2

- **Scripts**:
  - `PlayerController.cs`
  - `CameraController.cs` (an MainCamera)

### MainCamera Setup:
1. Im Player → Rechtsklick → Camera
2. Position: (0, 0.6, 0) (relativ zum Player)
3. Far Clipping Plane: 1000
4. Field of View: 60

## Schritt 4: Store Environment

### Floor:
- Plane (scale: 10, 1, 10)
- Material: Concrete/Tile
- Add BoxCollider

### Walls:
- 4x Cubes für Wände
- Positions/Scales anpassen
- Material: Wall/Paint
- Add BoxCollider

### Regale mit Kleidungsartikeln:
```csharp
// Für jedes Regal:
GameObject shelf = new GameObject("Shelf_1");
// Cube hinzufügen
// ClothingItem.cs Script hinzufügen
// Properties:
// - Price: 50
// - Item Name: "T-Shirt", "Jeans", "Jacket" etc.
```

### Tür zum Backroom:
- Cube als Door Frame
- Child: Door_Pivot (Quad oder Cube)
- Script: `Door.cs`
- Properties:
  - Open Angle: 90
  - Close Angle: 0
  - Rotation Speed: 2

## Schritt 5: Backroom Setup

### Pflanzen:
1. Für jede Pflanze:
   - GameObject: Cylinder oder Cube (als Topf)
   - Add Sphere/Capsule (als Pflanze)
   - Script: `Plant.cs`
   - Materials: 
     - seedMaterial: Grün (hell)
     - grownMaterial: Grün (dunkel)
   - Properties:
     - Growth Time: 60 (Sekunden)
     - Harvest Price: 200

## Schritt 6: GameManager Setup

### GameObject "GameManager":
1. Empty GameObject erstellen
2. Script: `GameManager.cs` hinzufügen
3. Im Inspector zuweisen:
   - Money Text: (Canvas → MoneyText)
   - Day Text: (Canvas → DayText)
   - Time Text: (Canvas → TimeText)

### Initial Money: 100000

## Schritt 7: UI Canvas Setup

### Canvas erstellen:
1. Rechtsklick → UI → Canvas
2. Render Mode: Screen Space - Overlay

### UI Elemente:

#### MoneyText:
```
GameObject: "MoneyText"
Component: TextMeshProUGUI
Text: "$100000"
FontSize: 60
Color: Green
Anchor: Top-Left
```

#### DayText:
```
GameObject: "DayText"
Component: TextMeshProUGUI
Text: "Day: 1"
FontSize: 40
Color: White
Anchor: Top-Center
```

#### TimeText:
```
GameObject: "TimeText"
Component: TextMeshProUGUI
Text: "Time: 08:00"
FontSize: 40
Color: White
Anchor: Top-Right
```

#### DeliveryText:
```
GameObject: "DeliveryText"
Component: TextMeshProUGUI
Text: "Ready for delivery"
FontSize: 30
Color: Yellow
Anchor: Bottom-Right
```

#### NotificationText:
```
GameObject: "NotificationText"
Component: TextMeshProUGUI
Text: ""
FontSize: 50
Color: Red
Anchor: Center
```

## Schritt 8: Customer Spawner Setup

### GameObject "CustomerSpawner":
1. Empty GameObject
2. Script: `CustomerSpawner.cs`
3. Properties:
   - Customer Prefab: (siehe Schritt 9)
   - Spawn Point: (Position vor dem Laden)
   - Spawn Interval: 20 (Sekunden)
   - Store Locations: Array mit 3-4 Positionen im Laden

## Schritt 9: Customer Prefab erstellen

### Prefab Setup:
1. Capsule (als Charakter)
2. Script: `Customer.cs`
3. Renderer mit Material
4. BoxCollider
5. Speichern als: `Assets/Prefabs/Customer.prefab`

## Schritt 10: Lighting

### Directional Light:
- Intensity: 1.2
- Color: White
- Shadows: Soft Shadows
- Rotation: (50, -30, 0)

### Ambient Light (Window → Rendering → Lighting):
- Intensity: 0.5
- Color: White

## Schritt 11: Physics & Colliders

```csharp
// Edit → Project Settings → Physics
// Gravity: (0, -9.81, 0)
// Default Material: Friction 0.4, Bounce 0.4
```

## Schritt 12: Input Manager Setup

```
Edit → Project Settings → Input Manager

Horizontal: A/D Keys
Vertical: W/S Keys
Mouse X/Y: Mouse
```

## Schritt 13: Build & Play Settings

```
File → Build Settings
- Scene: MainGame.unity
- Target Platform: PC/Mac/Linux Standalone
- Resolution: 1920x1080
- Quality: High
```

## Spielstart

1. **Play Button** drücken
2. **WASD** zum Bewegen
3. **E** zum Interagieren (Tür, Pflanzen, Artikel)
4. **R** für Skateboard-Lieferung
5. **ESC** zum Entsperren der Maus

## Häufige Fehler beheben

### Problem: Spieler fällt durch Boden
- **Lösung**: Floor Collider prüfen, Player Rigidbody auf Dynamic setzen

### Problem: Kamera bewegt sich nicht
- **Lösung**: CameraController auf MainCamera, Input Manager konfiguriert?

### Problem: Kunden erscheinen nicht
- **Lösung**: CustomerSpawner → Customer Prefab zugewiesen? Spawn Interval prüfen

### Problem: Türe dreht sich nicht
- **Lösung**: Door_Pivot als Child vorhanden? Door.cs Script zugewiesen?

### Problem: Polizei kommt nie
- **Lösung**: Aktuelle Zeit zwischen 10:00 und 20:00 Uhr? Door muss offen sein zum Testen

## Performance Tipps

1. **LOD (Level of Detail)** für Modelle
2. **Culling Mask** für unnötige Renderer
3. **Occlusion Culling** aktivieren
4. **Object Pooling** für Kunden
5. **Bake Lighting** für bessere Performance

## Nächste Schritte

- [ ] Sounds/Music hinzufügen
- [ ] Animationen für Charaktere
- [ ] Bessere Grafiken & Materials
- [ ] Mobile Controls implementieren
- [ ] Speichersystem
- [ ] Mitarbeiter-System
- [ ] Verschiedene Kleidungstypen

---

**Viel Spaß beim Spielen!** 🎮
