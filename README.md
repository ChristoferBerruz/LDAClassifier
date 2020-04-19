# LDAClassifier
LDA Classifier for the ATT Face Dataset. It currently achieves an accuracy of 89% with in a 50 dimension space.

PCA is required prior to using LDA to avoid singular matrices when trying to compute the eigen value
decomposition. In the implementation, we first map every image in the 10304 onto a 50 dimensional space.

Classification is later done by computing the LDA base, or W matrix, and comuting the projection of the images
in the 50 dimensional space to 39 dimensional space (C-1 space, C = 40 for 40 people or classes in ATT dataset).
We either use a linear discriminant that is done in the 50 dimensional space, or a closest neighbor
through L2 norm in the C-1 space.
