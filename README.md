# AR Skincare Product Scanner

A mobile **Augmented Reality (AR)** application built with **Unity** and **Vuforia** that recognizes skincare product packaging through image processing and displays interactive product information in real time.

Point your device camera at a supported product label to instantly view the product name, skin type, key ingredients, and usage details — powered by Vuforia image target tracking.

---

## Features

- **Image Target Recognition** — Detects printed product packaging using Vuforia Engine
- **Dynamic Product UI** — Shows product name on detection with an expandable details panel
- **Multi-Product Database** — Supports 11 skincare brands out of the box
- **Mobile AR Ready** — Built for Android with ARCore integration
- **Extensible Architecture** — Add new products by updating the Vuforia database and product list

---

## Supported Products

| Image Target ID       | Product Name                  |
|-----------------------|-------------------------------|
| `starville_cleanser`  | Starville Cleanser            |
| `avene`               | Avene Thermal Water           |
| `bioderma`            | Bioderma Micellar             |
| `bioderma_gel`        | Bioderma Gel Cleanser         |
| `cerave`              | CeraVe Lotion                 |
| `cetaphel`            | Cetaphil Cleanser             |
| `cleanclear`          | Clean & Clear Face Wash       |
| `eucerin`             | Eucerin Repair Cream          |
| `neutorgina`          | Neutrogena Face Wash          |
| `garnier`             | Garnier SkinActive            |
| `vaseline`            | Vaseline Moisturizer          |

---

## Tech Stack

| Technology | Version |
|------------|---------|
| Unity | 6000.4.0f1 |
| Vuforia Engine | 11.4.4 |
| AR Foundation | 6.4.x |
| XR Interaction Toolkit | 3.4.0 |
| TextMesh Pro | Built-in |
| Target Platform | Android (ARCore) |

---

## Prerequisites

Before opening the project, ensure you have the following installed:

1. **[Unity Hub](https://unity.com/download)** with **Unity 6000.4.0f1** (or compatible Unity 6 editor)
2. **Android Build Support** module (SDK, NDK, OpenJDK) via Unity Hub
3. A **[Vuforia Developer](https://developer.vuforia.com/)** account with a valid license key
4. A physical **Android device** with ARCore support and a rear camera (required for testing)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/YOUR_USERNAME/ar-skincare-product-scanner.git
cd ar-skincare-product-scanner
```

### 2. Install Vuforia Engine Package

This project references Vuforia Engine as a local package. If the package is not included in the repository:

1. Download **Vuforia Engine 11.4.4** for Unity from the [Vuforia Developer Portal](https://developer.vuforia.com/downloads/sdk)
2. Place the `.tgz` file in the project root directory
3. Confirm `Packages/manifest.json` contains:

```json
"com.ptc.vuforia.engine": "file:com.ptc.vuforia.engine-11.4.4.tgz"
```

### 3. Configure Your Vuforia License Key

> **Important:** Do not commit your personal Vuforia license key to a public repository.

1. Open the project in Unity
2. Go to **Window → Vuforia Configuration**
3. Paste your license key from the [Vuforia License Manager](https://developer.vuforia.com/vui/develop/licenses)

### 4. Open the Project

1. Launch **Unity Hub**
2. Click **Add → Add project from disk**
3. Select the project folder containing `My project.sln`
4. Open the project with Unity **6000.4.0f1**

### 5. Run the Application

1. Open the scene **`Assets/Scenes/ARScene.unity`**
2. Connect your Android device via USB with **USB Debugging** enabled
3. Go to **File → Build Settings**
4. Select **Android** as the platform
5. Click **Build and Run**, or use **Play Mode** with a webcam for basic editor testing

---

## How It Works

```
Camera Feed → Vuforia Image Target Detection → ProductInfoManager → UI Display
```

1. The device camera streams live video to **Vuforia Engine**
2. When a registered image target (product label) is detected, Vuforia fires an **OnTargetFound** event
3. **`ProductInfoManager`** matches the target name against the product database
4. The UI panel displays the product name; tapping **Show Details** reveals full product information
5. When the target leaves the frame, **OnTargetLost** hides the UI

---

## Project Structure

```
├── Assets/
│   ├── Scenes/
│   │   └── ARScene.unity              # Main AR scene
│   ├── Scripts/
│   │   └── ProductInfoManager.cs      # Core product detection & UI logic
│   ├── StreamingAssets/
│   │   └── Vuforia/
│   │       ├── my_db.xml              # Image target configuration
│   │       └── my_db.dat              # Compiled Vuforia database
│   ├── Resources/
│   │   └── VuforiaConfiguration.asset # Vuforia settings (license key)
│   └── Plugins/
│       └── Android/
│           └── AndroidManifest.xml    # Android permissions & AR config
├── Packages/
│   └── manifest.json                  # Unity package dependencies
└── ProjectSettings/                   # Unity project configuration
```

---

## Adding a New Product

1. **Create an image target** in the [Vuforia Target Manager](https://developer.vuforia.com/targetmanager)
2. Download the database and import it into Unity (or update `my_db.xml` / `my_db.dat`)
3. In the **ARScene**, select the **ProductInfoManager** GameObject
4. Add a new entry to the **Products** list in the Inspector:

   | Field | Example |
   |-------|---------|
   | Image Name | `new_product_id` (must match Vuforia target name exactly) |
   | Product Name | `Brand Product Name` |
   | Details | Full product description |

5. Rebuild and deploy to your device

---

## Building for Android

1. **File → Build Settings → Android → Switch Platform**
2. Configure **Player Settings**:
   - **Minimum API Level:** 24 or higher (recommended)
   - **Scripting Backend:** IL2CPP
   - **Target Architectures:** ARM64
3. Ensure camera permissions are granted (configured in `AndroidManifest.xml`)
4. Click **Build and Run**

---

## Troubleshooting

| Issue | Solution |
|-------|----------|
| Target not detected | Ensure good lighting, hold the camera steady, and verify the image target name matches exactly |
| Black camera screen | Check Vuforia license key and camera permissions on the device |
| Build fails on Android | Install Android SDK/NDK via Unity Hub; verify IL2CPP and ARM64 are enabled |
| Vuforia package missing | Download and place the `.tgz` package as described in Getting Started |
| Unknown product shown | Confirm `imageName` in ProductInfoManager matches the Vuforia target ID (case-sensitive) |

---

## Security Notes for GitHub

Before pushing to a public repository:

- Replace your Vuforia license key with a placeholder or use environment-specific configuration
- Add a Unity `.gitignore` to exclude `Library/`, `Temp/`, `Logs/`, `Build/`, and `.vs/` folders
- Do not commit large binary build artifacts or personal API keys

---

## Acknowledgments

- [Vuforia Engine](https://developer.vuforia.com/) by PTC for image target tracking
- [Unity AR Foundation](https://unity.com/unity/features/ar) for cross-platform AR support
- [TextMesh Pro](https://docs.unity3d.com/Packages/com.unity.textmeshpro@latest) for UI text rendering

---

## License

This project was developed as an **Image Processing final project**.  
Specify your license here (e.g., MIT) or mark as **Academic / Educational Use Only**.

---

## Author

**Your Name**  
Image Processing — Final Project  
[GitHub Profile](https://github.com/YOUR_USERNAME)

---

## Demo

<!-- Replace with a screenshot or GIF of the app in action -->
<!-- ![App Demo](docs/demo.gif) -->

> _Add a screenshot or screen recording of the AR app scanning a product to showcase the project on your GitHub profile._
