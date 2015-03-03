from django.db import models


class Tag(models.Model):
    name = models.SlugField()

    def __str__(self):
        return self.name

    class Meta:
        db_tablespace = 'blog'


class Post(models.Model):
    slug = models.SlugField(unique=True)
    title = models.CharField(max_length=50)
    content = models.TextField(max_length=10000)
    tags = models.ManyToManyField(Tag)
    posted_datetime = models.DateTimeField(auto_now=True)

    def __str__(self):
        return self.slug

    def tags_line(self):
        tags = self.tags.all()
        if tags:
            return ' '.join(tag.name for tag in tags)
        else:
            return ''

    class Meta:
        db_tablespace = 'blog'
        ordering = ['-posted_datetime']


