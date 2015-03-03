from django.test import TestCase
from blog.models import *


class PostIntegrationTests(TestCase):
    def setUp(self):
        tag1 = Tag.objects.create(id=1, name='web')
        tag2 = Tag.objects.create(id=2, name='git')

        post1 = Post.objects.create(id=1)
        post1.tags.add(tag1, tag2)

    def test_tags_line_null_tags(self):
        """tags_line should return empty string for null tags"""
        post1 = Post.objects.get(id=1)  # or get(pk=1)
        post1.tags.clear()
        self.assertEqual(post1.tags_line(), '')

    def test_tags_line_should_concatenate(self):
        """tags_line should return concatenated string with all tag names"""
        post1 = Post.objects.get(id=1)
        self.assertEqual(post1.tags_line(), 'web git')