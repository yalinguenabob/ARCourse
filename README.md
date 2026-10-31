# ARCourse
# AR Placement – Unity AR Foundation

> 🇬🇧 **Summary:** a mobile AR scene built with Unity and AR Foundation. Tap the screen and a 3D model is placed on a detected real-world surface, using plane detection, point cloud visualization, raycasting and the new Input System.

![Demo](Media/demo.gif)

## 📱 Présentation

Scène de réalité augmentée pour smartphone : l'utilisateur touche l'écran et un **modèle 3D apparaît sur la surface réelle détectée** (sol, table…).

Ce projet m'a permis de comprendre la chaîne complète d'une expérience AR : tracking, détection de surfaces, placement d'objet et gestion des entrées tactiles.

## ✨ Fonctionnalités

- Détection des surfaces horizontales (et verticales) en temps réel
- Visualisation des points caractéristiques du tracking
- Placement d'un modèle 3D par toucher de l'écran
- Entrées gérées avec le **nouveau Input System** (Input Action, Pointer)
- Fonctionne sur smartphone (build testé sur appareil réel)

## 🧰 Stack technique

| Élément | Détail |
|---|---|
| Moteur | Unity 6 (`[version exacte]`) |
| Framework AR | AR Foundation `[version]` |
| Plugin | ARCore XR Plugin (Android) / ARKit XR Plugin (iOS) |
| Entrées | Input System (Input Action, Pointer) |
| Langage | C# |

## 🧩 Composants AR utilisés

| Composant | Rôle |
|---|---|
| **AR Session** | Gère le cycle de vie de la session AR |
| **XR Origin** | Point d'origine de l'espace AR et caméra |
| **AR Plane Manager** | Détecte les surfaces planes et crée un `ARPlane` pour chacune |
| **AR Point Cloud Manager** | Affiche les points caractéristiques repérés par le tracking |
| **AR Raycast Manager** | Lance un rayon depuis l'écran pour trouver où poser l'objet |

### Fonctionnement

```
Point Cloud  →  Plane Manager  →  Raycast Manager  →  Objet 3D placé
(points)        (surfaces)        (position exacte)
```

1. Le tracking repère des points caractéristiques dans l'environnement
2. Ces points sont regroupés en plans
3. Au toucher, un raycast depuis l'écran touche un plan
4. Le modèle 3D est instancié à la position et à l'orientation du point touché

## 🚀 Installation

### Prérequis

- Unity 6 avec le module de build **[Android / iOS]**
- Un smartphone compatible ARCore / ARKit
- Pour Android : mode développeur et débogage USB activés

### Lancer le projet

```bash
git clone https://github.com/TON-PSEUDO/ar-foundation-placement.git
```

1. Ouvrir le dossier dans **Unity Hub**
2. Ouvrir la scène `Assets/Scenes/[NomDeLaScene].unity`
3. `File > Build Settings` → choisir la plateforme → **Switch Platform**
4. Brancher le smartphone, puis **Build And Run**

### APK prêt à tester

L'APK est disponible dans l'onglet [**Releases**](../../releases).

## 🎮 Utilisation

1. Lancer l'application et autoriser l'accès à la caméra
2. Bouger lentement le smartphone pour que les plans soient détectés
3. Toucher une surface détectée : le modèle 3D apparaît

## 📂 Structure du projet

```
Assets/
├── Scenes/        # Scène AR principale
├── Scripts/       # Script de placement (Input Action + Raycast)
├── Prefabs/       # Modèle 3D et prefabs de plans
├── Input/         # Input Actions asset
└── Models/        # Modèles 3D
Media/             # GIF et captures pour le README
```

## 📚 Ce que j'ai appris

- Comment fonctionnent le tracking, les plans et le raycast en AR
- Configurer AR Foundation (XR Origin, AR Session, managers)
- Utiliser le nouveau Input System pour gérer le toucher (Input Action, Pointer)
- Builder et tester sur un vrai appareil

## 🔭 Pistes d'amélioration

- [ ] Déplacer l'objet existant au lieu d'en créer un nouveau
- [ ] Ignorer les touches sur l'interface (UI)
- [ ] Masquer les plans et les points après le placement
- [ ] Rotation et mise à l'échelle par gestes
- [ ] Occlusion et ombres pour un rendu plus réaliste

## 🙏 Crédits et références

- Formation XR de **Dilmer** : `[lien de la formation]`
- Documentation officielle : [AR Foundation](https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@latest)
- Modèle 3D : `[nom de l'auteur / source / licence]`

## 👤 Auteur

**[Ton nom]**, développeur XR junior, en recherche de stage

- Portfolio : `[lien]`
- LinkedIn : `[lien]`

## 📄 Licence

Code sous licence MIT. Les assets tiers restent soumis à leur licence d'origine.
