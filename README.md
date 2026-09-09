# Clothing Store Simulator

Ein hybrid Wirtschaftsspiel kombiniert aus Supermarket Simulator, Schedule 1 Pflanzenanbau und Deliveroo-Lieferungen.

## Features

### 🏪 Hauptmerkmale

1. **Kleidungsladen Management**
   - 3D-Perspektive wie Supermarket Simulator
   - Kunden kommen und kaufen Kleidung
   - iPad-ähnliche Verkaufsmechanik
   - Realistische Grafiken

2. **Backroom Farming (Schedule 1)**
   - Pflanzen anbauen und ernten
   - Zusätzliche Einnahmequelle
   - Sichere Tür für Privatsphäre

3. **Skateboard Deliveries (Deliveroo)**
   - Lieferungen außerhalb des Ladens
   - Höhere Bezahlung für Lieferungen
   - Skateboard-Mechanik

4. **Polizeikontrolle & Risiko**
   - Zufällige Polizeibesuche
   - Geldstrafe bei offener Tür ($5,000)
   - Spannung & Strategie

5. **Wirtschaftssystem**
   - Start mit $100,000 Guthaben
   - Realistische Einnahmen/Ausgaben
   - Tägliches Geschäftsmodell

## Spielmechanik

### Steuerung
- **WASD** - Bewegung
- **E** - Interagieren (Tür, Pflanzen, Artikel)
- **R** - Skateboard-Lieferung starten
- **Maus** - Kamera bewegen

### Tagesablauf
- Öffnung: 8:00 Uhr
- Schließung: 22:00 Uhr
- Polizeikontrolle: 10:00 - 20:00 Uhr (Zufällig)

### Einkommensquellen
- **Kleidungsverkauf**: $50 pro Item
- **Pflanzenernte**: $200 pro Pflanze
- **Lieferungen**: $150 pro Lieferung

### Ausgaben
- **Polizeigeldstrafe**: $5,000 (wenn Tür offen)

## Installation

1. Unity 2021.3+ erforderlich
2. Repository klonen
3. Assets/Scenes/MainGame öffnen
4. Play drücken

## Projektstruktur

```
Assets/
├── Scripts/
│   ├── GameManager.cs          # Wirtschaft & Zeit
│   ├── PlayerController.cs     # Spielerbewegung
│   ├── Door.cs                 # Tür-Mechanik
│   ├── ClothingItem.cs         # Kleidungsartikel
│   ├── Plant.cs                # Pflanzen-Anbau
│   ├── Customer.cs             # Kunden-KI
│   ├── CustomerSpawner.cs      # Kunden-Spawning
│   ├── DeliveryManager.cs      # Liefersystem
│   ├── UIManager.cs            # UI-Interface
│   └── IInteractable.cs        # Interface
├── Prefabs/
│   ├── Customer.prefab
│   ├── Plant.prefab
│   └── ClothingItem.prefab
└── Scenes/
    └── MainGame.unity
```

## Zukünftige Features

- [ ] Mitarbeiter-Hiring System
- [ ] Mehrere Kleidungstypen mit verschiedenen Preisen
- [ ] Lager-Management
- [ ] Mehrspielermodus
- [ ] Mobile App Integration
- [ ] Bessere Grafiken & Animationen

## Credits

Inspiriert von:
- Supermarket Simulator
- Schedule 1
- Deliveroo

## Lizenz

MIT License
