# RandomForestScamPrevention
# Predictive Risk Scoring in Banking

**Author:** Alexander Hernandez  
**Course:** CSCI497 – Capstone  
**Date:** 1/24/2026  

---
## Dependencies & Setup Requirements

- To successfully build and run this project, ensure the following dependencies and configurations are met:

**Required Libraries**
-Microsoft.ML – Core machine learning framework used for model creation and prediction
-Microsoft.ML.FastTree (FastForest) – Used to implement the Random Forest algorithm

**These can be installed via NuGet Package Manager in Visual Studio.**

---

## Platform Requirement
**The project must be run in x64 architecture**
In Visual Studio:
- Go to Build → Configuration Manager
- Set Active solution platform → x64

**Failure to use x64 may result in runtime errors or model training issues.**

---

## Solution Dependency Setup
**Ensure that:**
**CapstoneProjectRandomForest.sln depends on ScamModelTrainer**
- In Visual Studio:
- Right-click solution → Project Dependencies
- Set CapstoneProjectRandomForest to depend on ScamModelTrainer

**This ensures the trained model is built before the UI attempts to use it.**

---

## Project Structure Overview

**This project is divided into two main components:**

**CapstoneProjectRandomForest (Main Application) -**

This is the UI-based application
Built using Windows Forms (Visual Studio)
Integrates the trained AI model
Responsible for:
- Taking user input (transaction data and such)
Displaying:
- Risk score
- Risk visualizations (Risk gauge or guage if you cant spell like me.)
- Recommended actions (Allow, Flag, Block)

**ScamModelTrainer (Model Training Module) -**

This is a console-based application
Responsible for:
- Training the Random Forest model
- Evaluating performance
Displaying:
- Accuracy
- Confusion matrix
- Prediction metrics

Used during development to analyze learning behavior and improve the model

---

## Project Overview

Banks process thousands of user actions and transactions daily. Some transactions carry higher risk due to unusual amounts, device changes, or location shifts. Traditional rule-based systems often fail to detect evolving fraud patterns and generate high false positives.  

This project implements a **Predictive Risk Scoring System** using a **Random Forest model** to assess the risk of individual banking actions. By learning from historical transaction and user behavior data, the system assigns a risk score between 0 and 1, enabling real-time decisions such as allowing, flagging, or blocking transactions.

---

## Problem Statement

Traditional rule-based approaches in fraud detection are limited and prone to false positives. The goal of this capstone project is to design a system that can:

- Learn from historical transactions  
- Assess risk dynamically  
- Reduce false positives  
- Provide explainable, robust predictions  

---

## Entities

**Possible Entities:**

- Customer account ID  
- Recipient account ID  
- Transaction amount  
- Average transaction amount  
- Customer location  
- Recipient location  
- Transaction type  
- Currency type  
- Timestamp  
- Average transaction type  
- Device type  

**Actual Entities Used in Model:**

- Transaction amount  
- Average transaction amount  
- Customer location  
- Recipient location  
- Transaction type  
- Currency type  
- Timestamp  

---

## User Perspective

From a bank or user perspective, the system evaluates individual transactions and generates:

- **Risk Score:** 0.0 (no risk) → 1.0 (high risk)  
- **Recommended Action:** Allow, Flag, or Block  

By learning behavioral patterns, the system adapts to evolving fraud strategies, overcoming limitations of traditional rule-based systems.

---

## Modules

1. **Data Loading:** Load CSV dataset  
2. **Data Preprocessing:** Clean and ensure consistency  
3. **Feature Selection:** Random subset of features per split  
4. **Bootstrap Sampling:** Create random samples from dataset  
5. **Build Tree:** Learn decision rules mapping features to risk probability  
6. **Create Leaf Nodes:** Produce risk scores  
7. **Create All Trees:** Repeat above steps for multiple trees  
8. **Average Risk Scores:** Combine predictions across trees  

---

## Input and Output

**Input:**  
- Dataset of banking transactions (real or simulated)  

**Output:**  
- Risk score between 0–1  
- Recommended action based on risk score  

Example:  
- 0 → No action  
- 0.8–1 → Block transaction  

---

## Why Random Forest

Random Forest is chosen because it:

- Combines multiple decision trees for stable predictions  
- Reduces overfitting using random feature subsets  
- Captures complex, non-linear relationships  
- Produces probabilistic outputs for flexible thresholds  
- Is interpretable and effective for small to medium datasets  

Personal Note: This is the first time implementing a Random Forest, and it fits my interests in fraud detection and AI.

---

## Dataset

**Where did it come from?**
- The dataset of over 10,000 lines was synthetically generated using Mockaroo: https://mockaroo.com/

---

## Potential Extensions

1. **Other Applications:**  
   - Meal recommendation based on pantry items  
   - Predicting any observable patterns in data  

2. **Website Risk Prediction (Experimental):**  
   - Optional module to evaluate website domains  
   - Checks domain length, hyphens, and numbers  
   - Contributes to overall risk score  

---

## User Interface

- Input: Text boxes, drop-downs, and date picker for transaction data  
- Output:  
  - Risk score  
  - Risk gauge (ring)  
  - Risk breakdown (donut chart)  
  - Recommended action  

**UI Challenges:**  
- Labeling controls correctly in Visual Studio  
- Ensuring UI data matches the model input  

---

## Diagrams

- **Entity Relationship Diagram (ERD):**  
  Represents the relationships between Customer, Transaction, Device, and Location for accurate risk scoring  

- **Use Case Diagram:**  
  Shows how the bank interacts with the risk scoring system to submit transactions and receive risk scores  

- **Activity Diagram:**  
  Step-by-step flow from receiving transaction data → preprocessing → risk scoring → recommended action  

- **UI UML Diagram:**  
  Visual layout of input fields and display components  

---

## Confusion Matrix

- Will show classification performance for risk predictions (0 = safe, 1 = scam)  

---

**End of Document**
